using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SeriesDictionary.Domain.Entities
{
    public class Word
    {
        public int Id { get; set; }
        public string English { get; set; }
        public string Turkish { get; set; }
        public int DifficultyId { get; set; }

        public Difficulty Difficulty { get; set; }
        public int? ShowId { get; set; } // Opsiyonel olarak hangi dizi/filmle ilişkili olduğu
        public Show Show { get; set; }
        public ICollection<WordEpisode> WordEpisodes { get; set; }
        public ICollection<UserWord> UserWords { get; set; }
        public ICollection<CategoryWord> CategoryWords { get; set; }
        public ICollection<FlashCard> FlashCards { get; set; }
        public string Sentence { get; set; } // Tek bir örnek cümle

        public Word()
        {
            WordEpisodes = new List<WordEpisode>();
            UserWords = new List<UserWord>();
            CategoryWords = new List<CategoryWord>();
            FlashCards = new List<FlashCard>();
        }
    }

}
