
using Domain.Entities.Organizations;

namespace Application.Interfaces.Entities;

public interface IOrganizationRepository
{
    Task<Organization?> GetByIdAsync(Guid id);
    Task AddAsync(Organization organization);
    Task UpdateAsync(Organization organization);
}