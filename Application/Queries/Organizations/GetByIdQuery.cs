using Domain.Entities.Organizations;
using MediatR;

namespace Application.Queries.Organizations
{
    public class GetByIdQuery : IRequest<Organization>
    {
        public OrganizationId Id { get; set; }
    }
}
