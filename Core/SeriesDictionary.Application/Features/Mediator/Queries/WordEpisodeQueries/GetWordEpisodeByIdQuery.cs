using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Results.WordEpisodeResults;

namespace SeriesDictionary.Application.Features.Mediator.Queries.WordEpisodeQueries
{
    public class GetWordEpisodeByIdQuery : IRequest<List<WordEpisodeByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetWordEpisodeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
