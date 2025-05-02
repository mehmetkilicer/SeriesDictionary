using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Dto.QuizDto;

namespace SeriesDictionary.Application.Features.Mediator.Queries.QuizQueries
{
    public class GetQuizQuery : IRequest<QuizViewModel>
    {
        public int EpisodeId { get; set; }
        public int DifficultyId { get; set; }
        public int QuestionCount { get; set; }
    }
}
