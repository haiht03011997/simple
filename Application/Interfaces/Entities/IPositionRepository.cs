using Domain.AggregateRoot.Organizations.Entities.Positions;

namespace Application.Interfaces.Entities;

public interface IPositionRepository
{
    Task<Position?> GetByIdAsync(Guid id);
    Task AddAsync(Position position);
}