using Application.Commands.Staffs.Create;
using Application.Queries.Organizations;
using AutoMapper;
using Contracts.Request.Staffs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
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

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListStaffQuery request)
    {
        var result = await _mediator.Send(request);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStaffRequest request)
    {
        var command = _mapper.Map<CreateStaffCommand>(request);
        await _mediator.Send(command);

        return Ok();
    }

}