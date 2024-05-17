using System.Linq.Expressions;
using Application.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{
    protected readonly DbContext _context;

    public UnitOfWork(DbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        using var saveChangeTask = _context.SaveChangesAsync(cancellationToken);
        return await saveChangeTask;
    }

    public DbSet<T> Set<T>(string name = null) where T : class
    {
        return _context.Set<T>(name);
    }

    public void AddOrUpdateGraph<TEntiy>(TEntiy entity, ICollection<Type> entitiesToBeUpdated = null) where TEntiy : class
    {
        var rootTypeEntity = entity.GetType();

        _context.ChangeTracker.TrackGraph(entity, e =>
        {
            Type navigationPropertyName = e.Entry.Entity.GetType();

            var alreadyTrackedEntity = _context.ChangeTracker.Entries().FirstOrDefault(entry => entry.Entity.Equals(e.Entry.Entity));

            if (alreadyTrackedEntity != null)
            {
                alreadyTrackedEntity.State = EntityState.Detached;
            }

            if (!navigationPropertyName.Equals(rootTypeEntity) && !(entitiesToBeUpdated != null && entitiesToBeUpdated.Contains(navigationPropertyName)))
            {
                e.Entry.State = EntityState.Unchanged;
            }
            else if (e.Entry.IsKeySet)
            {
                e.Entry.State = EntityState.Modified;
            }
            else
            {
                e.Entry.State = EntityState.Added;
            }
            System.Diagnostics.Debug.WriteLine($"Tracking {e.Entry.Metadata.DisplayName()} as {e.Entry.State}");
        });
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
