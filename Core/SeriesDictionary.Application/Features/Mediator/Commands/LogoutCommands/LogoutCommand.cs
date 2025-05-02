﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SeriesDictionary.Application.Features.Mediator.Commands.LogoutCommands
{
    public class LogoutCommand : IRequest
    {
        public string Token { get; }

        public LogoutCommand(string token)
        {
            Token = token;
        }
    }
}
