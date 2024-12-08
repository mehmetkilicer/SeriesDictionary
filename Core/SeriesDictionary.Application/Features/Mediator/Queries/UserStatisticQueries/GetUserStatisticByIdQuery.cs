using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Results.UserStatisticsResults;

namespace SeriesDictionary.Application.Features.Mediator.Queries.UserStatisticQueries
{
    public class GetUserStatisticByIdQuery : IRequest<List<GetUserStatisticByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetUserStatisticByIdQuery(int id)
        {
            Id = id;
        }
    }
}
