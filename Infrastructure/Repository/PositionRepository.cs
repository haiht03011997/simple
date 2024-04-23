using Application.Interfaces.Entities;
using Domain.Entities.Organizations;
using Domain.Entities.Positions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDbContext _context;

        public PositionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Position?> GetByIdAsync(Guid id)
        {
            return await _context.Positions
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddAsync(Position position)
        {
            await _context.Positions.AddAsync(position);
            await _context.SaveChangesAsync();
        }
    }
}
