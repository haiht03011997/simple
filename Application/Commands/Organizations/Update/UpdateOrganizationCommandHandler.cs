using Application.Exceptions;
using Application.Interfaces.Entities;
using Domain.AggregateRoot.Organizations.Entities.Positions;
using Domain.Entities.Organizations;
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
        Organization? organization = await _organizationRepository.GetByIdAsync(command.Id);

        if (organization == null)
        {
            throw new NotFoundException($"Organization with ID {command.Id} not found.");
        }

        organization.Update(command.OrgName, command.IsSameOrganization);
        await UpdatePosition(command, organization);

        await _organizationRepository.CreateOrUpdateAsync(organization);
    }

    private async Task UpdatePosition(UpdateOrganizationCommand command, Organization organization)
    {
        foreach (var positionCommand in command.OrgPosts)
        {
            Position position;
            if (!positionCommand.Id.HasValue)
            {
                position = Position.Create(
                    positionCommand.PostName,
                    positionCommand.PostType,
                    positionCommand.IsManager,
                    positionCommand.IsAccountable,
                    positionCommand.PersonIds);
                organization.UpdatePosition(position);
                //var existingPosition = await _positionRepository.GetByIdAsync(positionCommand.Id.Value);
                //if (existingPosition == null)
                //{
                //    throw new NotFoundException($"Position with ID {positionCommand.Id} not found.");
                //}
                //existingPosition.UpdateDetails(
                //    positionCommand.PostName,
                //    positionCommand.PostType,
                //    positionCommand.IsManager,
                //    positionCommand.IsAccountable);

                //existingPosition.UpdateStaff(positionCommand.PersonIds);
                //position = existingPosition;
            }
            //else
            //{
            //    position = Position.Create(
            //        positionCommand.PostName,
            //        positionCommand.PostType,
            //        positionCommand.IsManager,
            //        positionCommand.IsAccountable,
            //        positionCommand.PersonIds);
            //organization.UpdatePosition(position);
            //}

        }
    }
}