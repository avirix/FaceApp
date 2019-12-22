using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

using FaceDetector.Abstractions.Entities;
using FaceDetector.Domain.Models.Common;
using FaceDetector.Dtos;
using FaceDetector.Services.Helpers;

using Microsoft.IdentityModel.Tokens;

namespace FaceDetector.Services.Concrete
{
    public partial class UserService
    {
        public string Authenticate(BaseUser user, string password)
        {
            if (!PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new FaceAppException("Wrong email or password");
            return GetJwtToken(user);
        }

        public string GetJwtToken(BaseUser user)
        {
            return GenerateToken(GetIdentity(user).Claims);
        }

        public BaseUser GetUser(UserDto dto)
        {
            return Repository.GetAll().FirstOrDefault(x => x.Email == dto.Email);
        }

        public BaseUser Register(UserDto userDto)
        {
            if (GetUser(userDto) != null) throw new FaceAppException("User with this email already registered");
            BaseUser user = ToModel(userDto);
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

        private ClaimsIdentity GetIdentity(BaseUser user)
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
