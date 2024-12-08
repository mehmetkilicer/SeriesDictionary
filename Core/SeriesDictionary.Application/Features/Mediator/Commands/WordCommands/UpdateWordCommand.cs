﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Commands.WordCommands
{
    public class UpdateWordCommand : IRequest
    {
        public int Id { get; set; }
        public string English { get; set; }
        public string Turkish { get; set; }
        public int DifficultyId { get; set; }
    }
}
