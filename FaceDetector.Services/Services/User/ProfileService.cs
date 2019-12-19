using AutoMapper;
using AutoMapper.Configuration;

using FaceDetector.Abstractions.Repositories;
using FaceDetector.Domain.Models.Entities;
using FaceDetector.Dtos;
using FaceDetector.Services.Abstract;

namespace FaceDetector.Services.Services
{
    public class UserProfileService : BaseModelService<UserProfile, UserProfileDto>, IUserProfileService
    {

        public UserProfileService(IMapper mapper, IUserProfileRepository userProfileRepository)
            : base(mapper, userProfileRepository)
        {
        }
    }
}
