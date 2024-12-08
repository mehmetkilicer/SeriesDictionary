using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SeriesDictionary.Application.Features.Mediator.Commands.QuizCommands
{
    public class UpdateQuizCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
