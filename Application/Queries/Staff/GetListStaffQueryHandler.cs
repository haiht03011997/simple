using Application.Interfaces.Entities;
using AutoMapper;
using Contracts.Responses.Staffs;
using MediatR;

namespace Application.Queries.Organizations
{
    public class GetListStaffQueryHandler : IRequestHandler<GetListStaffQuery, List<GetListStaffResponse>>
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IMapper _mapper;

        public GetListStaffQueryHandler(IStaffRepository staffRepository, IMapper mapper)
        {
            _staffRepository = staffRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListStaffResponse>> Handle(GetListStaffQuery request, CancellationToken cancellationToken)
        {
            var response = await _staffRepository.GetListAsync();
            var result = _mapper.Map<List<GetListStaffResponse>>(response);
            return result;
        }
    }
}
