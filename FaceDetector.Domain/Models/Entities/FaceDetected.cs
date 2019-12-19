using System;
using System.Collections.Generic;
using System.Text;
using FaceDetector.Abstractions.Entities;

namespace FaceDetector.Domain.Models.Entities
{
    public class FaceDetected : CommonModel<Guid>
    {
        public Guid ImageId { get; set; }
        public FaceAppImage Image { get; set; }
        public string DetectedOptions { get; set; }
    }
}
