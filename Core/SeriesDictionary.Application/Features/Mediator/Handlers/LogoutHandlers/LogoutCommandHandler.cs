using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Commands.LogoutCommands;
using SeriesDictionary.Application.Interfaces.LogoutInterface;

namespace SeriesDictionary.Application.Features.Mediator.Handlers.LogoutHandlers
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private readonly ILogoutRepository _logoutRepository;

        public LogoutCommandHandler(ILogoutRepository logoutRepository)
        {
            _logoutRepository = logoutRepository;
        }

        public Task Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            // Token'i geçersiz kıl
            _logoutRepository.InvalidateToken(request.Token);

            // Task dönüşü sağlanır, Unit.Value yerine sadece Task kullanılıyor
            return Task.CompletedTask;
        }
    }
}
