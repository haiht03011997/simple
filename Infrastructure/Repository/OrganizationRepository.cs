using Application.Interfaces.Entities;
using Domain.Entities.Organizations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationDbContext _context;

        public OrganizationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Organization?> GetByIdAsync(Guid id)
        {
            return await _context.Organizations.Include(x => x.Positions).ThenInclude(x => x.StaffPositions).ThenInclude(x => x.Staff)
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddAsync(Organization organization)
        {
            await _context.Organizations.AddAsync(organization);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Organization organization)
        {
            _context.Organizations.Update(organization);
            await _context.SaveChangesAsync();
        }
    }
}
