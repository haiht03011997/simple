using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Entities;
using Domain.Entities;

namespace Infrastructure.Repository;

public abstract class ReadOnlyGenericRepository<TEntity, TKey> : IReadOnlyGenericRepository<TEntity, TKey>, IDisposable where TEntity : BaseEntity<TKey>
{
    protected internal readonly IUnitOfWork _context;
    protected internal readonly DbSet<TEntity> _dbSet;

    public ReadOnlyGenericRepository(IUnitOfWork context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual async Task<TEntity> GetOneAsync(TKey id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }

    public virtual async Task<int> CountAsync()
    {
        var countTask = await _dbSet.CountAsync();
        return countTask;
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
