using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Results.FlashCardResults;

namespace SeriesDictionary.Application.Features.Mediator.Queries.FlashCardQueries
{
    public class GetFlashCardByIdQuery : IRequest<List<GetFlashCardByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetFlashCardByIdQuery(int id)
        {
            Id = id;
        }
    }
}
