using System;

namespace FaceDetector.Dtos
{
    public class UserProfileDto
    {
        public Guid UserId { get; set; }
        public string Bio { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
    }
}
