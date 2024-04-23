using Application.Exceptions;
using Application.Interfaces.Entities;
using Domain.Entities.Organizations;
using Domain.Entities.Positions;
using Domain.Entities.Staffs;
using MediatR;

namespace Application.Commands.Organizations.Create;

public class UpdateOrganizationCommandHandler :
    IRequestHandler<UpdateOrganizationCommand>
{
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IPositionRepository _positionRepository;

    public UpdateOrganizationCommandHandler(
        IOrganizationRepository organizationRepository, IPositionRepository positionRepository)
    {
        _organizationRepository = organizationRepository;
        _positionRepository = positionRepository;
    }

    public async Task Handle(UpdateOrganizationCommand command, CancellationToken cancellationToken)
    {
        OrganizationId organizationId = new OrganizationId(command.OrganizationId);
        Organization? organization = await _organizationRepository.GetByIdAsync(organizationId);

        if (organization == null)
        {
            throw new NotFoundException($"Organization with ID {command.OrganizationId} not found.");
        }

        organization.Update(command.Name);
        await UpdatePosition(command, organization);

        await _organizationRepository.UpdateAsync(organization);
    }

    private async Task UpdatePosition(UpdateOrganizationCommand command, Organization organization)
    {
        foreach (var positionCommand in command.CreatePositionCommands)
        {
            Position position;
            if (positionCommand.PositionId.HasValue)
            {
                PositionId positionId = new PositionId(positionCommand.PositionId.Value);
                var existingPosition = await _positionRepository.GetByIdAsync(positionId);
                if (existingPosition == null)
                {
                    throw new NotFoundException($"Position with ID {positionCommand.PositionId} not found.");
                }
                existingPosition.UpdateDetails(positionCommand.Name, positionCommand.Description);
                existingPosition.UpdateStaff(positionCommand.StaffIds?.Select(id => new StaffId(id)).ToList());
                position = existingPosition;
            }
            else
            {
                position = Position.Create(
                    positionCommand.Name,
                    positionCommand.Description,
                    positionCommand.StaffIds?.Select(id => new StaffId(id)).ToList());
            }

            organization.UpdatePosition(position);
        }
    }
}