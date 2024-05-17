using Application.Interfaces.Entities;
using AutoMapper;
using Contracts.Responses.Organization;
using MediatR;

namespace Application.Queries.Organizations
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdOrgResponse>
    {

        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdOrgResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _organizationRepository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetByIdOrgResponse>(response);
            return result;
        }
    }
}
