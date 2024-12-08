using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Results.UserWordResults
{
    public class GetUserWordQueryResult
    {
        public int UserId { get; set; }
        public int WordId { get; set; }
        public bool IsMemorized { get; set; }
    }
}
