using Application.Interfaces.Data;
using Domain.Entities;
using Domain.Entities.GroupTitles;
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
        public DbSet<GroupTitle> GroupTitles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is AuditedEntityBase && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entityEntry in entities)
            {
                var entity = (BaseEntity<Guid>)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added)
                {
                    entity.SetCreationAudit("System"); // You can pass the actual user here if available
                }

                entity.SetUpdateAudit("System"); // You can pass the actual user here if available
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
