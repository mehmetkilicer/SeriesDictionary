using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Commands.EpisodeComands;
using SeriesDictionary.Domain.Entities;

namespace SeriesDictionary.Application.Features.Mediator.Handlers.EpisodeHandlers
{
    //public class CreateEpisodeCommandHandler : IRequestHandler<CreateEpisodeCommand>
    //{
    //    private readonly ApplicationDbContext _context;

    //    public CreateEpisodeCommandHandler(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<Unit> Handle(CreateEpisodeCommand request, CancellationToken cancellationToken)
    //    {
    //        var newEpisode = new Episode
    //        {
    //            Season = request.Season,
    //            EpisodeNumber = request.EpisodeNumber
    //        };

    //        _context.Episodes.Add(newEpisode);
    //        await _context.SaveChangesAsync(cancellationToken);

    //        return Unit.Value; // Void dönüş tipi için kullanılır.
    //    }
    //}
}
