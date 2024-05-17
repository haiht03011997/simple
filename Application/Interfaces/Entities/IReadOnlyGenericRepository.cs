using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Interfaces.Entities;

public interface IReadOnlyGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    Task<TEntity> GetOneAsync(TKey id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<bool> Exists(Expression<Func<TEntity, bool>> predicate);
    Task<int> CountAsync();
}
