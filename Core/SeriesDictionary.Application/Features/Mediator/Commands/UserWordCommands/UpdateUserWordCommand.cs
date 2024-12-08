using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Commands.UserWordCommands
{
    public class UpdateUserWordCommand : IRequest
    {
        public int UserId { get; set; }
        public int WordId { get; set; }
        public bool IsMemorized { get; set; }
    }
}
