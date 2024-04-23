using Domain.Entities.Staffs;
using MediatR;

namespace Application.Commands.Organizations.Create;

public record CreateOrganizationCommand(
    string Name,
    Guid? ParentOrganizationId,
    bool? IsSameLegal,
    List<CreatePositionCommand>? CreatePositionCommands) : IRequest;

public record CreatePositionCommand(
    string? Name,
    string? Description,
    bool? IsManage,
    Guid GroupTileId,
    List<Guid>? StaffIds) : IRequest;
