using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Application;
using SeriesDictionary.Application.Features.Mediator.Commands.ShowCommands;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Handlers.ShowHandlers
{
    public class DeleteShowCommandHandler : IRequestHandler<RemoveShowCommand>
    {
        private readonly IRepository<Show> _repository;

        public DeleteShowCommandHandler(IRepository<Show> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveShowCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
