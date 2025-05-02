using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Application;
using SeriesDictionary.Application.Features.Mediator.Queries.AppUserQueries;
using SeriesDictionary.Application.Features.Mediator.Results.AppUserResults;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<GetUserQueryResult>>
    {
        private readonly IRepository<AppUser> _repository;
        public GetUserQueryHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetUserQueryResult>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetUserQueryResult
            {
                AppUserId = x.AppUserId,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Username = x.Username,
                ProfileImage = x.ProfileImage,
                Password = x.Password,


            }).ToList();
        }
    }
}
