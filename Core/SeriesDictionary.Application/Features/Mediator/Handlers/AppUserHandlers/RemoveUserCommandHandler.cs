using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Application;
using SeriesDictionary.Application.Features.Mediator.Commands.AppUserCommands;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveAppUserCommand>
    {
        private readonly IRepository<AppUser> _repository;

        public RemoveUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAppUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
                throw new Exception("Kullanıcı bulunamadı");

            await _repository.RemoveAsync(user);
        }
    }
}
