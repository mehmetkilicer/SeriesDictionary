using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SeriesDictionary.Application.Application;
using SeriesDictionary.Application.Enums;
using SeriesDictionary.Application.Features.Mediator.Commands.AppUserCommands;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly PasswordHasher<AppUser> _passwordHasher;

        public UpdateUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
            _passwordHasher = new PasswordHasher<AppUser>(); // PasswordHasher örneği oluşturuldu
        }

        public async Task Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.AppUserId);

            if (values == null)
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }

            values.Name = request.Name;
            values.ProfileImage = request.ProfileImage;
            values.Username = request.Username;
            values.AppRoleId = (int)RolesType.Member; // Sabit rol ataması yerine request.AppRoleId kullanılabilir
            values.Email = request.Email;
            values.Surname = request.Surname;

            // Şifre boş veya null değilse güncelle
            if (!string.IsNullOrEmpty(request.Password))
            {
                values.Password = _passwordHasher.HashPassword(values, request.Password);
            }
            // Şifre null veya boşsa, mevcut şifre korunur (değişiklik yapmaya gerek yok)

            await _repository.UpdateAsync(values);
        }

    }
}
