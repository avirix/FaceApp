using FaceDetector.Abstractions.Entities;

namespace FaceDetector.Domain.Models.Entities
{
    public class User : BaseUser
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
