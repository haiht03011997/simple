using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Interfaces.Entities;

public interface IGenericRepository<TEntity, TKey> : IReadOnlyGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    Task<TEntity> CreateOrUpdateAsync(TEntity entity);
    Task<TEntity> CreateOrUpdateAsync(TEntity entity, ICollection<Type> entitiesToBeUpdated);
    Task DeleteByIdAsync(TKey id);
    Task DeleteAsync(TEntity entity);
    Task Clear();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    TEntity Add(TEntity entity);
    bool AddRange(params TEntity[] entities);
    TEntity Attach(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity UpdateFields(TEntity entity, params Expression<Func<TEntity, object>>[] properties);
    bool UpdateRange(params TEntity[] entities);
}
