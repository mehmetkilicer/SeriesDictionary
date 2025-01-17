using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Dto.WordDto
{
    public class UpdateWordDto
    {
        public int Id { get; set; }
        public string English { get; set; }
        public string Turkish { get; set; }
        public string Sentence { get; set; }
        public int DifficultyId { get; set; }
    }
}
