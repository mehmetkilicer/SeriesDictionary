using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SeriesDictionary.Application.Application;
using SeriesDictionary.Application.Enums;
using SeriesDictionary.Application.Features.Mediator.Commands.AppUserCommands;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly PasswordHasher<AppUser> _passwordHasher;

        public CreateAppUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
            _passwordHasher = new PasswordHasher<AppUser>(); // PasswordHasher örneği oluşturuldu
        }

        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new AppUser
            {
                ProfileImage = request.ProfileImage,
                Username = request.Username,
                AppRoleId = (int)RolesType.Member,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname
            };

            // Şifreyi hashleyerek ata
            newUser.Password = _passwordHasher.HashPassword(newUser, request.Password);

            await _repository.CreateAsync(newUser);
        }
    }
}
