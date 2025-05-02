using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeriesDictionary.Application.Features.Mediator.Commands.LogoutCommands;

namespace SeriesDictionary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LogoutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Logoout()
        {
            var authHeader = Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                return BadRequest("Token bulunamadı veya geçersiz.");
            }

            var token = authHeader.Replace("Bearer ", "");

            var command = new LogoutCommand(token);
            await _mediator.Send(command);

            return Ok(new { message = "Logout successful", logoutTime = DateTime.UtcNow });
        }
    }
}

