using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeriesDictionary.Application.Features.Mediator.Commands.QuizCommands;
using SeriesDictionary.Application.Features.Mediator.Queries.QuizQueries;
using SeriesDictionary.Application.Features.Mediator.Results.QuizResults;
using SeriesDictionary.Dto.QuizDto;



namespace SeriesDictionary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuizController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{episodeId}/{difficultyId}")]
        public async Task<ActionResult<QuizViewModel>> GetQuiz(int episodeId, int difficultyId, [FromQuery] int questionCount = 10)
        {
            var query = new GetQuizQuery { EpisodeId = episodeId, DifficultyId = difficultyId, QuestionCount = questionCount };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPost("submit")]
        public async Task<ActionResult<QuizResultViewModel>> SubmitQuiz([FromBody] SubmitQuizCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }

}
