using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Results.CategoryWordsResults
{
    public class GetCategoryWordsByIdQueryResult
    {
        public int CategoryId { get; set; }
        public int WordId { get; set; }
    }
}
