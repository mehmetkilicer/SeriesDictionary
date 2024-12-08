using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Domain.Entities
{
    public class FlashCard
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public Word Word { get; set; }
        public string ContextSentence { get; set; }
    }
}
