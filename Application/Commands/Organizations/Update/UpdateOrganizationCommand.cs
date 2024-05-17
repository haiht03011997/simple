using MediatR;
using VPG_QLKH_Organization.Enums;

namespace Application.Commands.Organizations.Create;

public record UpdateOrganizationCommand(
    Guid Id,
    Guid? ParentAdministrativeId,
    string OrgName,
    bool? IsSameOrganization,
    Guid? PIC,
    List<UpdatePositionCommand> OrgPosts) : IRequest;

public record UpdatePositionCommand(
    Guid? Id,
    PostType PostType,
    string PostName,
    bool? IsManager,
    bool? IsAccountable,
    List<Guid> PersonIds,
    bool? IsDeleted) : IRequest;
