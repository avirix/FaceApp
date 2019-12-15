using AutoMapper;

using Dtos;

using FaceDetector.Abstractions.Entities;

namespace FaceDetector.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDto, BaseUser>().ReverseMap();
        }
    }
}
