using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Results.AppUserResults;

namespace SeriesDictionary.Application.Features.Mediator.Queries.AppUserQueries
{
    public class GetUserQuery :IRequest<List<GetUserQueryResult>>
    {
    }
}
