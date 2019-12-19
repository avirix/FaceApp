using System.Collections.Generic;

namespace FaceDetector.Dtos
{
    public class ImageFolderDto
    {
        public string FolderName { get; set; }
        public List<FaceAppImageDto> Images { get; set; }
    }
}
