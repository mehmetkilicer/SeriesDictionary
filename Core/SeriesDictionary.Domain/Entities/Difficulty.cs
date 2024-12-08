using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Domain.Entities
{
    public class Difficulty
    {
        public int Id { get; set; }
        public string Level { get; set; } 
        public ICollection<Word> Words { get; set; }

        public Difficulty()
        {
            Words = new List<Word>();
        }
    }
}
