using System;
using System.Collections.Generic;
using System.Text;

namespace FaceDetector.Dtos
{
    public class FolderDto
    {
        public string FolderName { get; set; }
        public List<ImageDto> Images { get; set; }
    }
}
