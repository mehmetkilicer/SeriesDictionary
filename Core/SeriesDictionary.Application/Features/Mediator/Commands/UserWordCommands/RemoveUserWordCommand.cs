using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SeriesDictionary.Application.Features.Mediator.Commands.UserWordCommands
{
    public class RemoveUserWordCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveUserWordCommand(int id)
        {
            Id = id;
        }
    }
}
