using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Dto.SeriesDto
{
    public class CreateShowDto
    {
        public string title { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string? imageUrl1 { get; set; }
        public string? imageUrl2 { get; set; }
        public string? imageUrl3 { get; set; }
    }
}
