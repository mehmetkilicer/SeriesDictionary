using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SeriesDictionary.Application.Features.Mediator.Commands.WordEpisodeCommands
{
    public class RemoveWordEpisodeCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveWordEpisodeCommand(int id)
        {
            Id = id;
        }
    }
}
