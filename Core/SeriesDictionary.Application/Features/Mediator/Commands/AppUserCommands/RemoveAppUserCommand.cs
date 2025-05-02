using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SeriesDictionary.Application.Features.Mediator.Commands.AppUserCommands
{
    public class RemoveAppUserCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveAppUserCommand(int id)
        {
            Id = id;
        }
    }
}
