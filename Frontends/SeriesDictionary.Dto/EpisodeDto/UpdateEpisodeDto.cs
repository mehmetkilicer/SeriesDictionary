using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Dto.EpisodeDto
{
    public class UpdateEpisodeDto
    {
        public int Id { get; set; }
        public int Season { get; set; }
        public int EpisodeNumber { get; set; }
    }
}
