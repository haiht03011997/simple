using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces.Entities;

public interface IUnitOfWork : IDisposable
{
    DbSet<T> Set<T>(string name = null) where T : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    void AddOrUpdateGraph<TEntiy>(TEntiy entity, ICollection<Type> entitiesToBeUpdated = null) where TEntiy : class;
}
