using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Results.WordResults
{
    public class GetWordByIdQueryResult
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

     
    }
}
