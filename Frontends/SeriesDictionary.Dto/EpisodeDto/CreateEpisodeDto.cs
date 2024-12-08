using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Dto.EpisodeDto
{
    public class CreateEpisodeDto
    {
        public int Season { get; set; }
        public int EpisodeNumber { get; set; }
    }
}
