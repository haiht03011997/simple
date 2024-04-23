using Application.Interfaces.Entities;
using Domain.Entities.Organizations;
using Domain.Entities.Positions;
using Domain.Entities.Staffs;
using MediatR;

namespace Application.Commands.Organizations.Create;

public class CreateOrganizationCommandHandler :
    IRequestHandler<CreateOrganizationCommand>
{
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IPositionRepository _positionRepository;

    public CreateOrganizationCommandHandler(
        IOrganizationRepository organizationRepository, IPositionRepository positionRepository)
    {
        _organizationRepository = organizationRepository;
        _positionRepository = positionRepository;
    }

    public async Task Handle(CreateOrganizationCommand command, CancellationToken cancellationToken)
    {
        Organization organization = Organization.Create(name: command.Name,
                                                        positions: command.CreatePositionCommands.ConvertAll(cpc => 
                                                        Position.Create(cpc.Name, cpc.Description, cpc.StaffIds.ConvertAll(stf => new StaffId(stf)))));

        await _organizationRepository.AddAsync(organization);
    }
}