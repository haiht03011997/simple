using Contracts.Responses.Staffs;
using MediatR;

namespace Application.Queries.Organizations
{
    public class GetListStaffQuery : IRequest<List<GetListStaffResponse>>
    {
    }
}
