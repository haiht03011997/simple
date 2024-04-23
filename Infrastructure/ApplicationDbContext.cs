using Application.Interfaces.Data;
using Domain.Entities.Organizations;
using Domain.Entities.Positions;
using Domain.Entities.StaffPositions;
using Domain.Entities.Staffs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for your entities
        public DbSet<Organization> Organizations { get; set; } = null!;
        public DbSet<Staff> Staffs { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<StaffPosition> StaffPositions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
