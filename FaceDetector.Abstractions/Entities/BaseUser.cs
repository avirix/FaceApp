using System;

namespace FaceDetector.Abstractions.Entities
{
    public abstract class BaseUser : CommonModel<Guid>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
