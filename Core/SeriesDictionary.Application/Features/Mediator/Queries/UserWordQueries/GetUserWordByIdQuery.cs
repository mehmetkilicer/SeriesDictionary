using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Results.UserWordResults;

namespace SeriesDictionary.Application.Features.Mediator.Queries.UserWordQueries
{
    public class GetUserWordByIdQuery : IRequest<List<GetUserWordByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetUserWordByIdQuery(int id)
        {
            Id = id;
        }
    }
}
