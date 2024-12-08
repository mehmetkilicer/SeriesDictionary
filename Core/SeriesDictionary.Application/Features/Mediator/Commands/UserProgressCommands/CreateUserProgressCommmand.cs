using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Commands.UserProgressCommands
{
    public class CreateUserProgressCommmand : IRequest
    {
        public int UserId { get; set; }
        public int EpisodeId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
