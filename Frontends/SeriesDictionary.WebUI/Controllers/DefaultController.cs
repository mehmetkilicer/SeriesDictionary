using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeriesDictionary.Dto.MovieDto;
using SeriesDictionary.Dto.MovieDto.SeriesDictionary.Application.DTOs;
using SeriesDictionary.Dto.WordDto;
using SeriesDictionary.Persistence.Context;

namespace SeriesDictionary.WebUI.Controllers
{
    public class DefaultController : Controller 
    {
        private readonly DictionaryContext _context;

        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory, DictionaryContext context)
        {
            _httpClientFactory = httpClientFactory;
            _context = context;
        }

        public async Task<IActionResult> Index(int episodeId, int difficultyId)
        {
            var apiUrl = $"https://localhost:7257/api/WordEpisode/byEpisodeAndDifficulty?episodeId={episodeId}&difficultyId={difficultyId}";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(apiUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var words = JsonConvert.DeserializeObject<List<WordsByEpisodeAndDifficultyDto>>(jsonData);
                return View(words);
            }

            return View();
        }

    }
}
