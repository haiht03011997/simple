
using Domain.Entities.Organizations;

namespace Application.Interfaces.Entities;

public interface IOrganizationRepository : IGenericRepository<Organization, Guid>
{
    Task<Organization?> GetByIdAsync(Guid id);
    Task AddAsync(Organization organization);
    Task UpdateAsync(Organization organization);
    Task<dynamic> GetGraph();
}