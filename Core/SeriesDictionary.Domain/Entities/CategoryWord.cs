using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Domain.Entities
{
    public class CategoryWord
    {
        public int CategoryWordId { get; set; }  // Anahtar alan eklendi
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int WordId { get; set; }
        public Word Word { get; set; }
    }

}
