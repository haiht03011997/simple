using Application.Commands.Organizations.Create;
using AutoMapper;
using Contracts.Request.Organizations;
using Contracts.Responses.Organization;
using Domain.Entities.Organizations;

namespace WebApi.Common.Mapping;

public class OrganizationMappingConfig : Profile
{
    public OrganizationMappingConfig()
    {
        CreateMap<CreateOrganizationRequest, CreateOrganizationCommand>()
            .ForMember(cpc => cpc.OrgPosts, otp => otp.MapFrom(cpr => cpr.createPositionRequests))
        .ReverseMap();

        CreateMap<Organization, GetByIdOrgResponse>()
            .ForMember(cpc => cpc.OrgName, otp => otp.MapFrom(cpr => cpr.Name))
            .ForMember(dto => dto.OrgPosts, otp => otp.MapFrom(org => org.Positions))
        .ReverseMap();
    }
}