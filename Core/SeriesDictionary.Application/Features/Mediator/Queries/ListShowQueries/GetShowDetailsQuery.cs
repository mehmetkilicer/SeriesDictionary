using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Results.EpisodeResults;

namespace SeriesDictionary.Application.Features.Mediator.Queries.ListShowQueries
{
    public class GetShowDetailsQuery : IRequest<ShowDetailsViewModel>
    {
        public int Id { get; set; }

        public GetShowDetailsQuery(int id)
        {
            Id = id;
        }
    }

}
