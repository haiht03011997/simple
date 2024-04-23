using MediatR;

namespace Application.Commands.Staffs.Create
{
    public record CreateStaffCommand(string Name, string Email) : IRequest;
}
