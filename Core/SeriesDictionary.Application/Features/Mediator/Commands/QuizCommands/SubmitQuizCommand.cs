using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Queries.QuizQueries;
using SeriesDictionary.Application.Features.Mediator.Results.QuizResults;

namespace SeriesDictionary.Application.Features.Mediator.Commands.QuizCommands
{
    public class SubmitQuizCommand : IRequest<QuizResultViewModel>
    {
        public int EpisodeId { get; set; }
        public List<QuizAnswer> Answers { get; set; }
    }
}
