using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Results.CategoryResults;
using SeriesDictionary.Application.Features.Mediator.Results.CategoryWordsResults;

namespace SeriesDictionary.Application.Features.Mediator.Queries.CategoryWordQueries
{
    public class GetCategoryWordByIdQuery: IRequest<List<GetCategoryWordsByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetCategoryWordByIdQuery(int id)
        {
            Id = id;
        }
    }
}
