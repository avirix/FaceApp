using System;
using System.Collections.Generic;
using System.Text;
using FaceDetector.Abstractions.Entities;

namespace FaceDetector.Domain.Models.Entities
{
    public class ImageFolder : CommonModel<Guid>
    {
        public string FolderName { get; set; }
        public List<FolderUserProfile> UsersProfiles { get; set; }
        public List<FaceAppImage> Images { get; set; }
    }
}
