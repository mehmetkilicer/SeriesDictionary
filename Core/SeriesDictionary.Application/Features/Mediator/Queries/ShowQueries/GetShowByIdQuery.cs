using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Results.ShowResults;

namespace SeriesDictionary.Application.Features.Mediator.Queries.ShowQueries
{
    public class GetShowByIdQuery : IRequest<GetShowByIdQueryResult>
    {
        public int Id { get; set; }

        public GetShowByIdQuery(int id)
        {
            Id = id;
        }
    }

}
