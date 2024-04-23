using Application.Commands.GroupTiles.Create;
using AutoMapper;
using Contracts.GroupTitles;

namespace WebApi.Common.Mapping
{
    public class GroupTitleMappingConfig : Profile
    {
        public GroupTitleMappingConfig()
        {
            CreateMap<CreateGroupTitleRequest, CreateGroupTitleCommand>()
            .ReverseMap();
        }
    }
}
