using Domain.Entities.GroupTitles;

namespace Application.Interfaces.Entities;

public interface IGroupTitleRepository
{
    Task<GroupTitle?> GetByIdAsync(Guid id);
    Task AddAsync(GroupTitle groupTitle);
}