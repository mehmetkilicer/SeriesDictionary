using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SeriesDictionary.Application.Features.Mediator.Commands.FlashCardCommands
{
    public class RemoveFlashCardCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveFlashCardCommand(int id)
        {
            Id = id;
        }
    }
}
