using Application.Commands.Staffs.Create;
using AutoMapper;
using Contracts.Staffs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("Staffs")]
[AllowAnonymous]
public class StaffController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public StaffController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStaffRequest request)
    {
        var command = _mapper.Map<CreateStaffCommand>(request);
        await _mediator.Send(command);

        return Ok();
    }

}