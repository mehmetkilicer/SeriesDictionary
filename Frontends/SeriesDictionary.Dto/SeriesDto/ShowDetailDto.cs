using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Dto.SeriesDto
{
    public class ShowDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string ImageUrl1 { get; set; }
        public List<SeasonDetailDto> Seasons { get; set; }
    }
}
