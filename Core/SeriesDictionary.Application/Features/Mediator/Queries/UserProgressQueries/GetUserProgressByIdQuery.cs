using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Results.UserProgressResults;

namespace SeriesDictionary.Application.Features.Mediator.Queries.UserProgressQueries
{
    public class GetUserProgressByIdQuery : IRequest<List<GetUserProgressByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetUserProgressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
