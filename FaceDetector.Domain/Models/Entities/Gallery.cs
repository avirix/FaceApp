using System;
using System.Collections.Generic;
using System.Text;
using FaceDetector.Abstractions.Entities;

namespace FaceDetector.Domain.Models.Entities
{
    public class Gallery : CommonModel<Guid>
    {
        public string GalleryName { get; set; }
        public List<ImageFolder> Folders { get; set; }
    }
}
