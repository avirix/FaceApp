using FaceDetector.Abstractions.Services;
using FaceDetector.Domain.Models.Common;
using FaceDetector.Dtos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FaceDetector.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] UserDto userDto)
        {
            var user = userService.GetUser(userDto) ?? throw new FaceAppException("User with such email doesn't exist");
            var tokenString = userService.Authenticate(user, userDto.Password);
            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                user.Id,
                user.Email,
                Token = tokenString
            });
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] UserDto userDto)
        {
            // save 
            var user = userService.Register(userDto);
            var tokenString = userService.GetJwtToken(user);
            return Ok(new
            {
                user.Id,
                user.Email,
                Token = tokenString
            });
        }
    }
}