using Contracts.Responses.Organization;
using MediatR;

namespace Application.Queries.Organizations
{
    public class GetByIdQuery : IRequest<GetByIdOrgResponse>
    {
        public Guid Id { get; set; }
    }
}
