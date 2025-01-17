using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Domain.Entities;
using SeriesDictionary.Dto.WordDto;

namespace SeriesDictionary.Application.Features.Mediator.Queries.WordQueries
{
    public class GetWordsByEpisodeAndDifficultyQuery : IRequest<List<WordsByEpisodeAndDifficultyDto>>
    {
        public int EpisodeId { get; set; }
        public int DifficultyId { get; set; }

        public GetWordsByEpisodeAndDifficultyQuery(int episodeId, int difficultyId)
        {
            EpisodeId = episodeId;
            DifficultyId = difficultyId;
        }
    }
}
