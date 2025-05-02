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
    public class CreateShowCommandHandler : IRequestHandler<CreateShowCommand>
    {
        private readonly IRepository<Show> _repository;

        public CreateShowCommandHandler(IRepository<Show> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateShowCommand request, CancellationToken cancellationToken)
        {
            var newShow = new Show
            {
                Title = request.Title,
                Description = request.Description,
                Type = request.Type,
                ImageUrl1 = request.ImageUrl1,
                ImageUrl2 = request.ImageUrl2,
                ImageUrl3 = request.ImageUrl3
            };

            await _repository.CreateAsync(newShow); 
        }
    }
}
