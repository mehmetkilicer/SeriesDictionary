using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Application;
using SeriesDictionary.Application.Enums;
using SeriesDictionary.Application.Features.Mediator.Queries.AppUserQueries;
using SeriesDictionary.Application.Features.Mediator.Results.AppUserResults;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetAppUserByIdQueryHandler : IRequestHandler<GetAppUserByIdQuery, GetUserByIdQueryResult>
    {
        private readonly IRepository<AppUser> _repository;

        public GetAppUserByIdQueryHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);

            if (user == null)
                return null; // veya bir hata fırlatabilirsin

            return new GetUserByIdQueryResult
            {
                AppUserId =user.AppUserId,
                ProfileImage = user.ProfileImage,
                Password = user.Password,
                Username = user.Username,
                AppRoleId = (int)RolesType.Member,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname
            };
        }
    }

}
