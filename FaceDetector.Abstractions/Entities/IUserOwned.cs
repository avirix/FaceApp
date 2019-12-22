using System;

namespace FaceDetector.Abstractions.Entities
{
    public interface IUserOwned
    {
        public Guid UserId { get; set; }
        public BaseUser User { get; set; }
    }
}
