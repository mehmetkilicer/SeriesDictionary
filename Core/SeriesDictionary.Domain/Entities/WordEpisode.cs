using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SeriesDictionary.Domain.Entities
{
    public class WordEpisode
    {
        public int WordId { get; set; }
        public Word Word { get; set; }
        public int EpisodeId { get; set; }
        [JsonIgnore] // Döngü engellenir
        public Episode Episode { get; set; }
    }
}
