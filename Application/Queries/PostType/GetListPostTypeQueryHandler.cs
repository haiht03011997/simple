using Application.Interfaces.Entities;
using AutoMapper;
using Contracts.Helpers;
using Contracts.Responses.Staffs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VPG_QLKH_Organization.Enums;

namespace Application.Queries.Organizations
{
    public class GetListPostTypeQueryHandler : IRequestHandler<GetListPostTypeQuery, List<GetListPostTypeResponse>>
    {
        public async Task<List<GetListPostTypeResponse>> Handle(GetListPostTypeQuery request, CancellationToken cancellationToken)
        {
           var response = Enum.GetValues(typeof(PostType))
                                .Cast<PostType>()
                                .Select(x => new GetListPostTypeResponse
                                {
                                    Value = (int)x,
                                    Label = EnumHelper.GetDescription(x)
                                })
                                .ToList();
            return response;
        }
    }
}
