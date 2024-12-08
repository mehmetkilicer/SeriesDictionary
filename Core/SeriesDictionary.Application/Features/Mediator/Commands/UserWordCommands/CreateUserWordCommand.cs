using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Commands.UserWordCommands
{
    public class CreateUserWordCommand : IRequest
    {
        public int WordId { get; set; }
        public bool IsMemorized { get; set; }
    }
}
