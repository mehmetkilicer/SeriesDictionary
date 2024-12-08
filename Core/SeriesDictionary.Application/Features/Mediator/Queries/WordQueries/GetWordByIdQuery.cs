using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Results.WordResults;

namespace SeriesDictionary.Application.Features.Mediator.Queries.WordQueries
{
    public class GetWordByIdQuery : IRequest<List<GetWordByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetWordByIdQuery(int id)
        {
            Id = id;
        }
    }
}
