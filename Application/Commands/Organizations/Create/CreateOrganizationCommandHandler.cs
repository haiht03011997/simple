using Application.Interfaces.Entities;
using Domain.Entities.Organizations;
using Domain.Entities.Positions;
using MediatR;

namespace Application.Commands.Organizations.Create;

public class CreateOrganizationCommandHandler :
    IRequestHandler<CreateOrganizationCommand>
{
    private readonly IOrganizationRepository _organizationRepository;

    public CreateOrganizationCommandHandler(
        IOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public async Task Handle(CreateOrganizationCommand command, CancellationToken cancellationToken)
    {
        Organization organization = Organization.Create(command.OrgName,
                                                        command.ParentAdministrativeId,
                                                        command.IsSameOrganization,
                                                        command.PIC,
                                                        positions: command.OrgPosts?.ConvertAll(cpc =>
                                                        Position.Create(cpc.PostName, cpc.PostType, cpc.IsManager, cpc.IsAccountable, cpc.PersonIds)));

        await _organizationRepository.AddAsync(organization);
    }
}