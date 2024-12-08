using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public ICollection<WordEpisode> WordEpisodes { get; set; }
        public ICollection<UserWord> UserWords { get; set; }
        public ICollection<CategoryWord> CategoryWords { get; set; }

        // Relationship
        public ICollection<FlashCard> FlashCards { get; set; }

        public Word()
        {
            WordEpisodes = new List<WordEpisode>();
            UserWords = new List<UserWord>();
            CategoryWords = new List<CategoryWord>();
            FlashCards = new List<FlashCard>();
        }
    }
}
