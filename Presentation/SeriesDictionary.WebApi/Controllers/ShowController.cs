using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeriesDictionary.Application.Features.Mediator.Queries.ListShowQueries;
using SeriesDictionary.Application.Features.Mediator.Results.ListShowResults;

namespace SeriesDictionary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShowController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/show/movies
        [HttpGet("movies")]
        public async Task<ActionResult<List<GetMovieQueryResult>>> GetMovies()
        {
            // GetMoviesQuery sorgusunu MediatR aracılığıyla gönderiyoruz
            var movies = await _mediator.Send(new GetMoviesQuery());

            if (movies == null || movies.Count == 0)
            {
                return NotFound("No movies found.");
            }

            return Ok(movies); // HTTP 200 OK ile sonucu döndürüyoruz
        }

        // GET api/show/series
        [HttpGet("series")]
        public async Task<ActionResult<List<GetMovieQueryResult>>> GetSeries()
        {
            // Series için de benzer şekilde bir sorgu yazabilirsiniz.
            var series = await _mediator.Send(new GetSeriesQuery());

            if (series == null || series.Count == 0)
            {
                return NotFound("No series found.");
            }

            return Ok(series); // HTTP 200 OK ile sonucu döndürüyoruz
        }

        [HttpGet("details/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetShowDetails(int id)
        {
            var query = new GetShowDetailsQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


    }
}
