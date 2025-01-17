using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Dto.SeriesDto
{

    public class EpisodeDetailDto
    {
        public int Id { get; set; }
        public int ShowId { get; set; }
        public int Season { get; set; }
        public int EpisodeNumber { get; set; }
    }
}
