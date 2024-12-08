using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryWord> CategoryWords { get; set; }

        public Category()
        {
            CategoryWords = new List<CategoryWord>();
        }
    }

}
