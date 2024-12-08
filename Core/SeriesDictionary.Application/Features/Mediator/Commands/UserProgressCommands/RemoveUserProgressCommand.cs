using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SeriesDictionary.Application.Features.Mediator.Commands.UserProgressCommands
{
    public class RemoveUserProgressCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveUserProgressCommand(int id)
        {
            Id = id;
        }
    }
}
