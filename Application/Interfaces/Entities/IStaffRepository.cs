using Domain.Entities.Staffs;

namespace Application.Interfaces.Entities
{
    public interface IStaffRepository
    {
        Task AddAsync(Staff staff);
    }
}
