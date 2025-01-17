using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Dto.SeriesDto
{
    public class EpisodeDto
    {
        public int Id { get; set; }
        public int ShowId { get; set; } // Dizi ID
        public int Season { get; set; } // Sezon numarası
        public int EpisodeNumber { get; set; } // Bölüm numarası
    }
}
