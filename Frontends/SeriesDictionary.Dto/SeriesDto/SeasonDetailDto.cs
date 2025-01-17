using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Dto.SeriesDto
{
    public class SeasonDetailDto
    {
        public int SeasonNumber { get; set; } // Sezon numarası
        public List<EpisodeDto> Episodes { get; set; } // Sezon içindeki bölümler
    }
}
