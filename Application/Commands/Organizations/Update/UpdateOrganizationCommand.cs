using Domain.Entities.Staffs;
using MediatR;

namespace Application.Commands.Organizations.Create;

public record UpdateOrganizationCommand(
    Guid OrganizationId,
    string Name,
    List<UpdatePositionCommand> CreatePositionCommands) : IRequest;

public record UpdatePositionCommand(
    Guid? PositionId,
    string Name,
    string Description,
    List<Guid> StaffIds) : IRequest;
