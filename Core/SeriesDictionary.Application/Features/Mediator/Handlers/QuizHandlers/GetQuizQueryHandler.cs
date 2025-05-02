using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Queries.QuizQueries;
using SeriesDictionary.Application.Interfaces.WordEpisodeInterfaces;
using SeriesDictionary.Application.Interfaces.WordInterfaces;
using SeriesDictionary.Dto.QuizDto;

namespace SeriesDictionary.Application.Features.Mediator.Handlers.QuizHandlers
{
    public class GetQuizQueryHandler : IRequestHandler<GetQuizQuery, QuizViewModel>
    {
        private readonly IWordRepository _wordRepository;
        private readonly IWordEpisodeRepository _episodeRepository;

        public GetQuizQueryHandler(IWordRepository wordRepository, IWordEpisodeRepository episodeRepository)
        {
            _wordRepository = wordRepository;
            _episodeRepository = episodeRepository;
        }

        public async Task<QuizViewModel> Handle(GetQuizQuery request, CancellationToken cancellationToken)
        {
            var words = await _episodeRepository.GetWordsByEpisodeAndDifficultyAsync(request.EpisodeId, request.DifficultyId);
            var allWrongAnswers = await _wordRepository.GetRandomWordsAsync(request.QuestionCount * 5); // Daha büyük havuz

            var quizQuestions = new List<QuizQuestionViewModel>();
            var usedWrongAnswers = new HashSet<string>();

            foreach (var word in words.Take(request.QuestionCount))
            {
                var question = new QuizQuestionViewModel
                {
                    WordId = word.Id,
                    EnglishWord = word.English,
                    CorrectAnswer = word.Turkish,
                    Options = new List<string> { word.Turkish }
                };

                // Yanlış cevapları seçerken, daha önce seçilmiş cevapları hariç tut
                var wrongAnswers = allWrongAnswers
                    .Where(w => w.Id != word.Id && !usedWrongAnswers.Contains(w.Turkish))
                    .Select(w => w.Turkish)
                    .Take(3)
                    .ToList();

                usedWrongAnswers.UnionWith(wrongAnswers); // Kullanılan yanlış cevapları ekle
                question.Options.AddRange(wrongAnswers);
                question.Options = question.Options.OrderBy(o => Guid.NewGuid()).ToList(); // Şıkları karıştır

                quizQuestions.Add(question);
            }

            var episode = await _episodeRepository.GetEpisodeByIdAsync(request.EpisodeId);

            return new QuizViewModel
            {
                EpisodeId = episode.Id,
                EpisodeTitle = $"{episode.Show.Title} - Season {episode.Season} Episode {episode.EpisodeNumber}",
                Questions = quizQuestions
            };
        }
    }
}
