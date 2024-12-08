﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Results.QuizResults;

namespace SeriesDictionary.Application.Features.Mediator.Queries.QuizQuestionQueries
{
    public class GetQuizQuestionByIdQuery : IRequest<List<GetQuizByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetQuizQuestionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
