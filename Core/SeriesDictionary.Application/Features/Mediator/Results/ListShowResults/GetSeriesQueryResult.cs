using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesDictionary.Application.Features.Mediator.Results.ListShowResults
{
    public class GetSeriesQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImageUrl1 { get; set; } // Null olabilir
        public string? ImageUrl2 { get; set; } // Null olabilir
        public string? ImageUrl3 { get; set; } // Null olabilir
    }
}
