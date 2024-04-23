using Domain.Entities.Staffs;
using MediatR;

namespace Application.Commands.Organizations.Create;

public record CreateOrganizationCommand(
    string Name,
    List<CreatePositionCommand> CreatePositionCommands) : IRequest;

public record CreatePositionCommand(
    string Name,
    string Description,
    List<Guid> StaffIds) : IRequest;
