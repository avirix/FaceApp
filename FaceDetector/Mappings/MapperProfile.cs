using AutoMapper;

using FaceDetector.Abstractions.Entities;
using FaceDetector.Dtos;

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
