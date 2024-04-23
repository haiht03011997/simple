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
        Organization organization = Organization.Create(command.Name,
                                                        command.ParentOrganizationId,
                                                        command.IsSameLegal,
                                                        positions: command.CreatePositionCommands?.ConvertAll(cpc =>
                                                        Position.Create(cpc.Name, cpc.Description, cpc.IsManage, cpc.GroupTileId, cpc.StaffIds)));

        await _organizationRepository.AddAsync(organization);
    }
}