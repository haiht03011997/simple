using Application.Interfaces.Entities;
using Domain.Entities.Staffs;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Staff>> GetListAsync()
        {
            return await _context.Staffs.Where(x => !x.IsDeleted).ToListAsync();
        }
    }
}
