using Application.Interfaces.Entities;
using MediatR;

namespace Application.Queries.Organizations
{
    public class GetTreeOrganizationQueryHandler : IRequestHandler<GetTreeOrganizationQuery, object>
    {
        private readonly IOrganizationRepository _organizationRepository;

        public GetTreeOrganizationQueryHandler(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<object> Handle(GetTreeOrganizationQuery request, CancellationToken cancellationToken)
        {
            var result = await _organizationRepository.GetGraph();
            return result;
        }
    }
}
