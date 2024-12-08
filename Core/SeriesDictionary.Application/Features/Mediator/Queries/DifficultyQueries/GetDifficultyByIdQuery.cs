using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Results.CategoryWordsResults;
using SeriesDictionary.Application.Features.Mediator.Results.DifficultyResults;

namespace SeriesDictionary.Application.Features.Mediator.Queries.DifficultyQueries
{
    public class GetDifficultyByIdQuery : IRequest<List<GetDifficultyByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetDifficultyByIdQuery(int id)
        {
            Id = id;
        }
    }
}
