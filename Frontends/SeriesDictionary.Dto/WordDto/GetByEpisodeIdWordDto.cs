using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Dto.WordDto
{
 
    public class GetByEpisodeIdWordDto
    {
        public int WordId { get; set; }
        public string English { get; set; }
        public string Turkish { get; set; }
        public int EpisodeId { get; set; }
    }

}
