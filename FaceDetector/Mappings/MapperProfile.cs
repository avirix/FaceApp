using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dtos;
using FaceDetector.Domain.Models.Entities;
using AutoMapper;

namespace FaceDetector.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
