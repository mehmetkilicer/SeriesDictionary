using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Results.EpisodeResults;

namespace SeriesDictionary.Application.Features.Mediator.Queries.EpisodeQueries
{
    public  class GetEpisodeByIdQuery : IRequest<List<GetEpisodeByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetEpisodeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
