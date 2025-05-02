using Microsoft.AspNetCore.Mvc;
using MediatR; // IMediator için bu namespace'i ekleyin
using SeriesDictionary.Application.Features.Mediator.Queries.QuizQueries;
using Newtonsoft.Json;
using SeriesDictionary.Dto.QuizDto;
using SeriesDictionary.Application.Features.Mediator.Results.QuizResults;
using SeriesDictionary.Application.Features.Mediator.Commands.QuizCommands;
using System.Text; // GetQuizQuery için
//... diğer using'ler

namespace SeriesDictionary.WebUI.Controllers
{
    public class QuizController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public QuizController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Start(int episodeId, int difficultyId, int questionCount = 150)
        {
            try
            {
                // API URL'si
                var apiUrl = $"https://localhost:7257/api/Quiz/{episodeId}/{difficultyId}?questionCount={questionCount}";

                // HTTP client oluşturuluyor
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync(apiUrl);

                if (responseMessage.IsSuccessStatusCode)
                {
                    // API'den gelen JSON verisini deserialize ediyoruz
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var quizViewModel = JsonConvert.DeserializeObject<QuizViewModel>(jsonData); // QuizViewModel sınıfınızı burada kullanın

                    // Modeli View'a gönderiyoruz
                    return View("Start", quizViewModel);

                }
                else
                {
                    // API'den hata döndüğünde
                    ModelState.AddModelError("", "API'den veri alınırken bir hata oluştu.");
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                // Genel hata durumu
                ModelState.AddModelError("", "Bir hata oluştu: " + ex.Message);
                return View("Error");
            }
        }
        [HttpPost]
        [Route("Quiz/SubmitQuiz")]

        public async Task<ActionResult<QuizResultViewModel>> SubmitQuiz([FromBody] SubmitQuizCommand command)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var json = JsonConvert.SerializeObject(command);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:7257/api/quiz/process", content);

                if (response.IsSuccessStatusCode)
                {
                    var resultJson = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<QuizResultViewModel>(resultJson);

                    var incorrectAnswers = new List<IncorrectAnswerViewModel>();
                    foreach (var answer in command.Answers)
                    {
                        var question = result.Questions.FirstOrDefault(q => q.WordId == answer.WordId);
                        if (question != null && question.CorrectAnswer != answer.SelectedAnswer)
                        {
                            incorrectAnswers.Add(new IncorrectAnswerViewModel
                            {
                                WordId = question.WordId,
                                EnglishWord = question.EnglishWord,
                                CorrectAnswer = question.CorrectAnswer,
                                SelectedAnswer = answer.SelectedAnswer
                            });
                        }
                    }

                    var quizResult = new QuizResultViewModel
                    {
                        CorrectAnswers = result.CorrectAnswers,
                        TotalQuestions = result.TotalQuestions,
                        IncorrectAnswers = incorrectAnswers
                    };

                    return Ok(quizResult);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
            }
        }
    }
}
