using AutoMapper;

using FaceDetector.Abstractions.Entities;
using FaceDetector.Domain.Models.Entities;
using FaceDetector.Dtos;

namespace FaceDetector.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDto, BaseUser>().ReverseMap();
            CreateMap<FolderDto, ImageFolder>().ReverseMap();
            CreateMap<ImageDto, FaceAppImage>().ReverseMap();
        }
    }
}
