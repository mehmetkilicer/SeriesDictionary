using MediatR;
using SeriesDictionary.Application.Features.Mediator.Queries.ListShowQueries;
using SeriesDictionary.Application.Features.Mediator.Results.ListShowResults;
using SeriesDictionary.Application.Interfaces.MovieInterface;


namespace SeriesDictionary.Application.Features.Mediator.Handlers.MovieHandlers
{
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, List<GetMovieQueryResult>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<GetMovieQueryResult>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            // Repository'den tüm filmleri alıyoruz
            var movies = await _movieRepository.GetMoviesAsync();

            // Filmleri query result formatına dönüştürüyoruz
            return movies.Select(movie => new GetMovieQueryResult
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ImageUrl1 = movie.ImageUrl1,
                ImageUrl2 = movie.ImageUrl2,
                ImageUrl3 = movie.ImageUrl3
            }).ToList();
        }
    }
}
