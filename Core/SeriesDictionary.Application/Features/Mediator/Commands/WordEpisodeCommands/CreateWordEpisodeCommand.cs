using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Commands.WordEpisodeCommands
{
    public class CreateWordEpisodeCommand : IRequest
    {
        public int EpisodeId { get; set; }
    }
}
