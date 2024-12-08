﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SeriesDictionary.Application.Features.Mediator.Commands.EpisodeComands
{
    public class UpdateEpisodeCommand : IRequest
    {
        public int Id { get; set; }
        public int Season { get; set; }
        public int EpisodeNumber { get; set; }
    }
}
