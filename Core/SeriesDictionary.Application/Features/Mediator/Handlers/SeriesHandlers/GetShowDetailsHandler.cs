using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Queries.ListShowQueries;
using SeriesDictionary.Application.Features.Mediator.Results.EpisodeResults;
using SeriesDictionary.Application.Interfaces.SeriesInterfaces.SeriesDictionary.Application.Interfaces;

namespace SeriesDictionary.Application.Features.Mediator.Handlers.SeriesHandlers
{
    public class GetShowDetailsHandler : IRequestHandler<GetShowDetailsQuery, ShowDetailsViewModel>
    {
        private readonly IShowRepository _showRepository;

        public GetShowDetailsHandler(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }

        public async Task<ShowDetailsViewModel> Handle(GetShowDetailsQuery request, CancellationToken cancellationToken)
        {
            var show = await _showRepository.GetShowByIdAsync(request.Id);
            var episodes = await _showRepository.GetEpisodesByShowIdAsync(request.Id);
            var groupedEpisodes = episodes.GroupBy(e => e.Season)
                                          .Select(g => new SeasonViewModel
                                          {
                                              SeasonNumber = g.Key,
                                              Episodes = g.ToList()
                                          })
                                          .ToList();

            if (show == null)
            {
                return null; // Show bulunamazsa null döner
            }

            return new ShowDetailsViewModel
            {
                Show = show,
                Seasons = groupedEpisodes
            };
        }
    }

}

