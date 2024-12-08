﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Commands.FlashCardCommands
{
    public class UpdateFlashCardCommand : IRequest
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public string ContextSentence { get; set; }
    }
}
