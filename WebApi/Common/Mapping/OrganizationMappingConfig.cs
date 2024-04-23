using Application.Commands.Organizations.Create;
using AutoMapper;
using Contracts.Organizations;

namespace WebApi.Common.Mapping;

public class OrganizationMappingConfig : Profile
{
    public OrganizationMappingConfig()
    {
        CreateMap<CreateOrganizationRequest, CreateOrganizationCommand>()
            .ForMember(cpc => cpc.CreatePositionCommands, otp => otp.MapFrom(cpr => cpr.createPositionRequests))
        .ReverseMap();
    }
}