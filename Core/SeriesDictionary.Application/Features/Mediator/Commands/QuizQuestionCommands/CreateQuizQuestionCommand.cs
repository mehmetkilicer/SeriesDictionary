using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Commands.QuizQuestionCommands
{
    public class CreateQuizQuestionCommand : IRequest
    {
        public int QuizId { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
    }
}
