using Dtos;

using FaceDetector.Abstractions.Entities;

namespace FaceDetector.Abstractions.Services
{
    public interface IUserService : IBaseModelService<BaseUser, UserDto>
    {
        string Authenticate(BaseUser user, string password);
        BaseUser Register(UserDto userDto);
        BaseUser GetUser(UserDto dto);
        string GetJwtToken(BaseUser user);
    }
}
