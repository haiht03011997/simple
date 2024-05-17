using Application.Commands.Organizations.Create;
using Application.Queries.Organizations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[AllowAnonymous]
public class OrganizationController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public OrganizationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetTree([FromQuery] GetTreeOrganizationQuery command)
    {
        //var command = _mapper.Map<CreateOrganizationCommand>(request);
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdQuery command)
    {
        //var command = _mapper.Map<CreateOrganizationCommand>(request);
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrganizationCommand command)
    {
        //var command = _mapper.Map<CreateOrganizationCommand>(request);
        await _mediator.Send(command);

        return Ok();
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrganizationCommand command)
    {
        //var command = _mapper.Map<CreateOrganizationCommand>(request);
        await _mediator.Send(command);

        return Ok();
    }
}