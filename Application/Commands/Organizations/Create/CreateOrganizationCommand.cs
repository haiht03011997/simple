using MediatR;
using VPG_QLKH_Organization.Enums;

namespace Application.Commands.Organizations.Create;

public record CreateOrganizationCommand(
    Guid? ParentAdministrativeId,
    string OrgName,
    bool? IsSameOrganization,
    Guid? PIC,
    List<UpdatePositionCommand> OrgPosts) : IRequest;

public record CreatePositionCommand(
    PostType PostType,
    string PostName,
    bool? IsManager,
    bool? IsAccountable,
    List<Guid>? PersonIds) : IRequest;
