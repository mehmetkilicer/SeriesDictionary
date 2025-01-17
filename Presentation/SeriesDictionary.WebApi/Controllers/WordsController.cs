using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeriesDictionary.Application.Features.Mediator.Queries.WordQueries;
using SeriesDictionary.Application.Features.Mediator.Results.WordResults;

namespace SeriesDictionary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WordsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet("list")] // Endpoint: api/words/list
        //public async Task<IActionResult> WordList()
        //{
        //    // Burada GetWordQuery nesnesini gönderiyoruz
        //    var values = await _mediator.Send(new GetWordQuery());
        //    return Ok(values);  // Sonuçları başarıyla döndürüyoruz
        //}
    }
}
