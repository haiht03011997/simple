using Contracts.Responses.Staffs;
using MediatR;

namespace Application.Queries.Organizations
{
    public class GetListPostTypeQuery : IRequest<List<GetListPostTypeResponse>>
    {
    }
}
