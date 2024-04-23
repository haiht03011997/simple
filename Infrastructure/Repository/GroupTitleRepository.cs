using Application.Interfaces.Entities;
using Domain.Entities.GroupTitles;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class GroupTitleRepository : IGroupTitleRepository
    {
        private readonly ApplicationDbContext _context;

        public GroupTitleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GroupTitle?> GetByIdAsync(Guid id)
        {
            return await _context.GroupTitles
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddAsync(GroupTitle groupTitle)
        {
            await _context.GroupTitles.AddAsync(groupTitle);
            await _context.SaveChangesAsync();
        }
    }
}
