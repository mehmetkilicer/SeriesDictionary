using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Commands.QuizCommands;
using SeriesDictionary.Application.Features.Mediator.Results.QuizResults;
using SeriesDictionary.Application.Interfaces.WordInterfaces;

namespace SeriesDictionary.Application.Features.Mediator.Handlers.QuizHandlers
{
    public class SubmitQuizCommandHandler : IRequestHandler<SubmitQuizCommand, QuizResultViewModel>
    {
        private readonly IWordRepository _wordRepository;

        public SubmitQuizCommandHandler(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        public async Task<QuizResultViewModel> Handle(SubmitQuizCommand request, CancellationToken cancellationToken)
        {
            var correctAnswers = 0;

            foreach (var answer in request.Answers)
            {
                var word = await _wordRepository.GetWordByIdAsync(answer.WordId);
                if (word.Turkish == answer.SelectedAnswer)
                {
                    correctAnswers++;
                }
            }

            return new QuizResultViewModel
            {
                CorrectAnswers = correctAnswers,
                TotalQuestions = request.Answers.Count
            };
        }
    }
}
