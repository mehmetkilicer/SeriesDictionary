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
    public class UpdateShowCommandHandler : IRequestHandler<UpdateShowCommand>
    {
        private readonly IRepository<Show> _repository;

        public UpdateShowCommandHandler(IRepository<Show> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateShowCommand request, CancellationToken cancellationToken)
        {
            var values =await _repository.GetByIdAsync(request.Id);
            values.Title = request.Title;
            values.Description = request.Description;
            values.Type = request.Type;
            values.ImageUrl1 = request.ImageUrl1;
            values.ImageUrl2 = request.ImageUrl2;
            values.ImageUrl3 = request.ImageUrl3;
            await _repository.UpdateAsync(values);

        }
    }
}
