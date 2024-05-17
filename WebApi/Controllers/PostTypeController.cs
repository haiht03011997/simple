using Application.Queries.Organizations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostTypeController : ControllerBase
    {
        private readonly ISender _mediator;

        public PostTypeController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTree([FromQuery] GetListPostTypeQuery command)
        {
            //var command = _mapper.Map<CreateOrganizationCommand>(request);
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
