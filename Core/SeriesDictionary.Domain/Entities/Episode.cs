using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Domain.Entities
{
    public class Episode
    {
        public int Id { get; set; }
        public int ShowId { get; set; } // Hangi dizi/filme ait olduğu
        public Show Show { get; set; }
        public int Season { get; set; }
        public int EpisodeNumber { get; set; }
        public ICollection<WordEpisode> WordEpisodes { get; set; }
        public ICollection<UserProgress> UserProgresses { get; set; }

        public Episode()
        {
            WordEpisodes = new List<WordEpisode>();
            UserProgresses = new List<UserProgress>();
        }
    }

}
