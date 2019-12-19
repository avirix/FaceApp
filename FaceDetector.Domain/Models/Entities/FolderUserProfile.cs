using System;
using System.Collections.Generic;
using System.Text;

namespace FaceDetector.Domain.Models.Entities
{
    public class FolderUserProfile
    {
        public Guid FolderId { get; set; }
        public ImageFolder Folder { get; set; }
        public Guid ProfileId { get; set; }
        public UserProfile Profile { get; set; }
    }
}
