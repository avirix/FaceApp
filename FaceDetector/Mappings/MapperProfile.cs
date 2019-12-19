
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
            CreateMap<GalleryDto, Gallery>().ReverseMap();
            CreateMap<FaceDetectedDto, FaceDetected>().ReverseMap();
            CreateMap<FaceAppImageDto, FaceAppImage>().ReverseMap();
            CreateMap<UserProfileDto, UserProfile>().ReverseMap();
            CreateMap<ImageFolderDto, ImageFolder>().ReverseMap();
        }
    }
}
