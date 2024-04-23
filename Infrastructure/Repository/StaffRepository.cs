using Application.Interfaces.Entities;
using Domain.Entities.Organizations;
using Domain.Entities.Positions;
using Domain.Entities.Staffs;

namespace Infrastructure.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationDbContext _context;

        public StaffRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Staff staff)
        {
            await _context.Staffs.AddAsync(staff);
            await _context.SaveChangesAsync();
        }
    }
}
