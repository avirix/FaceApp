using System;
using System.Collections.Generic;

using FaceDetector.Abstractions.Entities;

using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

using Newtonsoft.Json;

namespace FaceDetector.Domain.Models.Entities
{
    public class FaceAppImage : CommonModel<Guid>, IUserOwned
    {
        #region ImageData
        public string FileExtension { get; set; }
        public string ImageBase64 { get; set; }
        public int ImageBase64Length { get; set; }
        public int? PictureWidth { get; set; }
        public int? PictureHeight { get; set; }
        public string AnalyzeResult { get; set; }
        #endregion ImageData

        #region FK
        public Guid UserId { get; set; }
        public BaseUser User { get; set; }
        public Guid FolderId { get; set; }
        public ImageFolder Folder { get; set; }
        #endregion FK

        public FaceAppImage() { }

        public FaceAppImage(string imageBase64) : this()
        {
            ImageBase64 = imageBase64.Substring(imageBase64.LastIndexOf(',') + 1);
            ImageBase64Length = ImageBase64.Length;
        }

        public FaceAppImage(string imageBase64, string result) : this(imageBase64)
        {
            AnalyzeResult = result;
        }

        public FaceAppImage(string imageBase64, IEnumerable<DetectedFace> result)
            : this(imageBase64, JsonConvert.SerializeObject(result))
        { }

        public string GetFullBase64() => $"data:image/{FileExtension};base64,{ImageBase64}";
    }
}
