using Application.Interfaces.Entities;
using Domain.Entities.Staffs;
using MediatR;

namespace Application.Commands.Staffs.Create
{
    internal class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand>
    {
        private readonly IStaffRepository _staffRepository;

        public CreateStaffCommandHandler(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public async Task Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
            Staff staff = Staff.Create(request.Name, request.Email);
            await _staffRepository.AddAsync(staff);
        }
    }
}
