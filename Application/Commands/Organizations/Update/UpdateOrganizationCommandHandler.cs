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
        Organization? organization = await _organizationRepository.GetByIdAsync(command.OrganizationId);

        if (organization == null)
        {
            throw new NotFoundException($"Organization with ID {command.OrganizationId} not found.");
        }

        organization.Update(command.Name, command.IsSameLegal, command.IsDeleted);
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
                var existingPosition = await _positionRepository.GetByIdAsync(positionCommand.PositionId.Value);
                if (existingPosition == null)
                {
                    throw new NotFoundException($"Position with ID {positionCommand.PositionId} not found.");
                }
                existingPosition.UpdateDetails(
                    positionCommand.Name,
                    positionCommand.Description,
                    positionCommand.IsManage,
                    positionCommand.GroupTitleId,
                    positionCommand.IsDeleted);

                existingPosition.UpdateStaff(positionCommand.StaffIds);
                position = existingPosition;
            }
            else
            {
                position = Position.Create(
                    positionCommand.Name,
                    positionCommand.Description,
                    positionCommand.IsManage,
                    positionCommand.GroupTitleId,
                    positionCommand.StaffIds);
            }

            organization.UpdatePosition(position);
        }
    }
}