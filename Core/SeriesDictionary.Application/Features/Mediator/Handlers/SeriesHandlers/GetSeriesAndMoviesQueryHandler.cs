using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SeriesDictionary.Application.Features.Mediator.Queries.ListShowQueries;
using SeriesDictionary.Application.Features.Mediator.Results.ListShowResults;
using SeriesDictionary.Application.Interfaces.SeriesInterfaces;

namespace SeriesDictionary.Application.Features.Mediator.Handlers.SeriesHandlers
{
    public class GetSeriesAndMoviesQueryHandler : IRequestHandler<GetSeriesAndMoviesQuery, List<GetSeriesAndMoviesQueryResult>>
    {
        private readonly ISeriesRepository _seriesRepository;

        public GetSeriesAndMoviesQueryHandler(ISeriesRepository seriesRepository)
        {
            _seriesRepository = seriesRepository;
        }
        public async Task<List<GetSeriesAndMoviesQueryResult>> Handle(GetSeriesAndMoviesQuery request, CancellationToken cancellationToken)
        {
            var SeriesAndMovies = await _seriesRepository.GetSeriesAndMovieAsync();
            return SeriesAndMovies.Select(s => new GetSeriesAndMoviesQueryResult
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                ImageUrl1 = s.ImageUrl1,
                ImageUrl2 = s.ImageUrl2,
                ImageUrl3 = s.ImageUrl3
            }).ToList();
        }
    }
}
