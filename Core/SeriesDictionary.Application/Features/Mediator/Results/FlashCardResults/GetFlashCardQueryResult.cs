using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Results.FlashCardResults
{
    public class GetFlashCardQueryResult
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public Word Word { get; set; }
        public string ContextSentence { get; set; }
    }
}
