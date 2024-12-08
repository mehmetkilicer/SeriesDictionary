using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SeriesDictionary.Application.Features.Mediator.Commands.DifficultyComands
{
    public class RemoveDifficultyCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveDifficultyCommand(int id)
        {
            Id = id;
        }
    }
}
