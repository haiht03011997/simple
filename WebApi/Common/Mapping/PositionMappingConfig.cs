using Application.Commands.Organizations.Create;
using AutoMapper;
using Contracts.Request.Organizations;
using Contracts.Responses.Organization;
using Domain.Entities.Organizations;
using Domain.Entities.Positions;

namespace WebApi.Common.Mapping;

public class PositionMappingConfig : Profile
{
    public PositionMappingConfig()
    {
        CreateMap<CreatePositionRequest, CreatePositionCommand>()
        .ReverseMap();

        CreateMap<Position, GetPositionResponse>()
            .ForMember(cpc => cpc.PersonIds, otp => otp.MapFrom(cpr => cpr.StaffPositions.Select(x => x.StaffId)))
       .ReverseMap();
    }
}