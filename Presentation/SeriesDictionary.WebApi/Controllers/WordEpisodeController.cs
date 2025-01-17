using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeriesDictionary.Application.Features.Mediator.Queries.WordQueries;
using SeriesDictionary.Domain.Entities;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SeriesDictionary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordEpisodeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WordEpisodeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("byEpisodeAndDifficulty")]
        public async Task<IActionResult> GetWordsByEpisodeAndDifficulty(int episodeId, int difficultyId)
        {
            var query = new GetWordsByEpisodeAndDifficultyQuery(episodeId, difficultyId);
            var result = await _mediator.Send(query);

            // Eğer sonuç boşsa 404 döndür
            if (result == null || result.Count == 0)
                return NotFound("Bu episode ve zorluk seviyesine uygun kelime bulunamadı.");

            // 200 - Başarılı sonuç
            return Ok(result);
        }
    }
}
