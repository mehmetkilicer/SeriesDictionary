using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Domain.Entities
{
    public class UserWord
    {
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public int WordId { get; set; }
        public Word Word { get; set; }
        public bool IsMemorized { get; set; }
    }
}
