using Application.Commands.Staffs.Create;
using AutoMapper;
using Contracts.Request.Staffs;
using Contracts.Responses.Staffs;
using Domain.Entities.Staffs;

namespace WebApi.Common.Mapping;

public class StaffMappingConfig : Profile
{
    public StaffMappingConfig()
    {
        CreateMap<CreateStaffRequest, CreateStaffCommand>()
        .ReverseMap();
        CreateMap<Staff, GetListStaffResponse>()
            .ForMember(staffDto => staffDto.Value, otp => otp.MapFrom(staff => staff.Id))
            .ForMember(staffDto => staffDto.Label, otp => otp.MapFrom(staff => staff.Name))
        .ReverseMap();
    }
}