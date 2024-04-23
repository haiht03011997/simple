using Application.Commands.Staffs.Create;
using AutoMapper;
using Contracts.Staffs;

namespace WebApi.Common.Mapping;

public class StaffMappingConfig : Profile
{
    public StaffMappingConfig()
    {
        CreateMap<CreateStaffRequest, CreateStaffCommand>()
        .ReverseMap();
    }
}