
using Domain.Entities.Organizations;
using Domain.Entities.Positions;
using Domain.Entities.Staffs;

namespace Application.Interfaces.Entities;

public interface IPositionRepository
{
    Task<Position?> GetByIdAsync(PositionId id);
    Task AddAsync(Position position);
}