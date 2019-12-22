
using AutoMapper;

using FaceDetector.Abstractions.Entities;
using FaceDetector.Abstractions.Repositories;
using FaceDetector.Abstractions.Services;
using FaceDetector.Dtos;

using Microsoft.Extensions.Configuration;

namespace FaceDetector.Services.Concrete
{
    public partial class UserService : BaseModelService<BaseUser, UserDto>, IUserService
    {
        readonly IConfiguration _configuration;

        public UserService(IMapper mapper, IConfiguration configuration, IUserRepository userRepository) : base(mapper, userRepository)
        {
            _configuration = configuration;
        }
    }
}
