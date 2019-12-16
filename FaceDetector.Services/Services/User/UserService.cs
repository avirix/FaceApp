
using AutoMapper;

using Dtos;

using FaceDetector.Abstractions.Entities;
using FaceDetector.Abstractions.Repositories;
using FaceDetector.Abstractions.Services;

using Microsoft.Extensions.Configuration;

namespace FaceDetector.Services.Services
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
