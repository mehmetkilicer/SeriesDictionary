using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Results.WordEpisodeResults
{
    public class WordEpisodeQueryResult
    {
        public int WordId { get; set; }
        public int EpisodeId { get; set; }
    }
}
