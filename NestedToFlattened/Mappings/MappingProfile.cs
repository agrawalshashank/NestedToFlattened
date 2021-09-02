using AutoMapper;
using Core.Models;
using NestedToFlattened.Dto;

namespace NestedToFlattened.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ObjectDto, ObjectDetails>();
            CreateMap<StopDto, Stop>();
            CreateMap<RouteDto, Route>();
        }
    }
}
