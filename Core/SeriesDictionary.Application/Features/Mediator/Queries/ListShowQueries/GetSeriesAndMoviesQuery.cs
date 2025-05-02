using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Results.ListShowResults;

namespace SeriesDictionary.Application.Features.Mediator.Queries.ListShowQueries
{
    public class GetSeriesAndMoviesQuery : IRequest<List<GetSeriesAndMoviesQueryResult>>
    {
    }
}
