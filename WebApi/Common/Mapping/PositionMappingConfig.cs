using Application.Commands.Organizations.Create;
using AutoMapper;
using Contracts.Organizations;

namespace WebApi.Common.Mapping;

public class PositionMappingConfig : Profile
{
    public PositionMappingConfig()
    {
        CreateMap<CreatePositionRequest, CreatePositionCommand>()
        .ReverseMap();
    }
}