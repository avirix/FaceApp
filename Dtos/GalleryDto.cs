using System.Collections.Generic;

namespace FaceDetector.Dtos
{
    public class GalleryDto
    {
        public string GalleryName { get; set; }
        public List<ImageFolderDto> Folders { get; set; }
    }
}
