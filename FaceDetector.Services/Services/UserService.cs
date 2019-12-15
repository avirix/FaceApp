using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using AutoMapper;

using Dtos;

using FaceDetector.Abstractions.Entities;
using FaceDetector.Abstractions.Repositories;
using FaceDetector.Abstractions.Services;
using FaceDetector.Domain.Models.Common;
using FaceDetector.Domain.Models.Entities;
using FaceDetector.Services.Helpers;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FaceDetector.Services.Services
{
    public class UserService : BaseModelService<BaseUser, UserDto>, IUserService
    {
        readonly IConfiguration _configuration;

        public UserService(IMapper mapper, IConfiguration configuration, IUserRepository userRepository) : base(mapper, userRepository)
        {
            _configuration = configuration;
        }

        public string Authenticate(BaseUser user, string password)
        {
            throw new NotImplementedException();
        }

        public string GetJwtToken(BaseUser user)
        {
            throw new NotImplementedException();
        }

        public BaseUser GetUser(UserDto dto)
        {
            throw new NotImplementedException();
        }

        public BaseUser Register(UserDto userDto)
        {
            if (GetUser(userDto) != null) throw new FaceAppException("User with this email already registered");
            User user = Mapper.Map<UserDto, User>(userDto);
            user.Id = Guid.NewGuid();
            user.PasswordSalt = PasswordHelper.CreateSalt();
            user.PasswordHash = PasswordHelper.CreatePasswordHash(userDto.Password, user.PasswordSalt);
            Repository.Create(user);
            ApiResponse.UserResponseMessage = "User successfully registered!";
            return user;
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:KEY"]));
            var jwt = new JwtSecurityToken(
                issuer: _configuration["Auth:ISSUER"],
                audience: _configuration["Auth:AUDIENCE"],
                notBefore: DateTime.Now,
                claims: claims,
                expires: DateTime.Now.AddHours(Convert.ToDouble(_configuration["Auth:LIFETIME"])),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private ClaimsIdentity GetIdentity(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };
            var claimsIdentity = new ClaimsIdentity(
                claims,
                "Token",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
