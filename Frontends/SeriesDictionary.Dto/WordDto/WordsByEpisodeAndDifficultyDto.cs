using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesDictionary.Dto.SeriesDto;

namespace SeriesDictionary.Dto.WordDto
{
    public class WordsByEpisodeAndDifficultyDto
    {
        public int Id { get; set; }
        public string English { get; set; }
        public string Turkish { get; set; }
        public int DifficultyId { get; set; }
        public string Sentence { get; set; }
        public ShowDto Show { get; set; } // Show bilgileri
    }
}
