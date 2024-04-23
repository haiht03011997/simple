using MediatR;

namespace Application.Commands.Organizations.Create;

public record UpdateOrganizationCommand(
    Guid OrganizationId,
    Guid ParentOrganizationId,
    string Name,
    bool? IsSameLegal,
    List<UpdatePositionCommand> CreatePositionCommands,
    bool? IsDeleted) : IRequest;

public record UpdatePositionCommand(
    Guid? PositionId,
    string Name,
    string Description,
    bool? IsManage,
    Guid GroupTitleId,
    List<Guid> StaffIds,
    bool? IsDeleted) : IRequest;
