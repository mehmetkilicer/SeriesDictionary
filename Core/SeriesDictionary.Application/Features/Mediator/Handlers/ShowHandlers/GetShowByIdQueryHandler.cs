using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Application;
using SeriesDictionary.Application.Features.Mediator.Queries.ShowQueries;
using SeriesDictionary.Application.Features.Mediator.Results.ShowResults;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Handlers.ShowHandlers
{
    public class GetShowByIdQueryHandler : IRequestHandler<GetShowByIdQuery, GetShowByIdQueryResult>
    {
        private readonly IRepository<Show> _repository;

        public GetShowByIdQueryHandler(IRepository<Show> repository)
        {
            _repository = repository;
        }

        public async Task<GetShowByIdQueryResult> Handle(GetShowByIdQuery request, CancellationToken cancellationToken)
        {
            var show = await _repository.GetByIdAsync(request.Id);

            if (show == null)
                return null;

            return new GetShowByIdQueryResult
            {
                Id = show.Id,
                Title = show.Title,
                Description = show.Description,
                Type = show.Type,
                ImageUrl1 = show.ImageUrl1,
                ImageUrl2 = show.ImageUrl2,
                ImageUrl3 = show.ImageUrl3
            };
        }
    }
}
