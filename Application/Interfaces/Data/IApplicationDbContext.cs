using Domain.Entities.GroupTitles;
using Domain.Entities.Organizations;
using Domain.Entities.Positions;
using Domain.Entities.StaffPositions;
using Domain.Entities.Staffs;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Organization> Organizations { get; set; }
        DbSet<Staff> Staffs { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<StaffPosition> StaffPositions { get; set; }
        DbSet<GroupTitle> GroupTitles { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
