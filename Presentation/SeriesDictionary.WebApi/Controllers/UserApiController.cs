using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeriesDictionary.Application.Features.Mediator.Commands.AppUserCommands;
using SeriesDictionary.Application.Features.Mediator.Queries.AppUserQueries;

namespace SeriesDictionary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("userlist")]
        public async Task<IActionResult> UserList()
        {
            var values = await _mediator.Send(new GetUserQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var value = await _mediator.Send(new GetAppUserByIdQuery(id));
            return Ok(value);
        }
        [HttpPost("useradd")]
        public async Task<IActionResult> CreateAuthor(CreateAppUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("User başarıyla eklendi");
        }
        [HttpDelete("userdelete")]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            await _mediator.Send(new RemoveAppUserCommand(id));
            return Ok("User başarıyla silindi");
        }
        [HttpPut("userupdate")]
        public async Task<IActionResult> UpdateAuthor(UpdateAppUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("User başarıyla güncellendi");
        }
    }
}
