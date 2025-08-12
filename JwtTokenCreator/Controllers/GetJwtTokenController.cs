using JwtTokenCreator.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtTokenCreator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetJwtTokenController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GetJwtTokenController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("JWTToken")]
        public async Task<IActionResult> Get()
        {
            var jwtroken = await _mediator.Send(new GetTokenQuery());
            return Ok(jwtroken);
        }
    }
}
