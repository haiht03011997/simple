using Application.Commands.Organizations.Create;
using AutoMapper;
using Contracts.Organizations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("Organization")]
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