using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SeriesDictionary.Application.Features.Mediator.Commands.ShowCommands
{
    public class RemoveShowCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveShowCommand(int id)
        {
            Id = id;
        }
    }
}
