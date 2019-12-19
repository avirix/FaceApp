using System;
using System.Collections.Generic;
using System.Text;
using FaceDetector.Abstractions.Entities;

namespace FaceDetector.Domain.Models.Entities
{
    public class UserProfile : CommonModel<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Bio { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public List<FolderUserProfile> UserFolders { get; set; }
    }
}
