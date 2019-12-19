using System.Collections.Generic;
using System.Threading.Tasks;
using FaceDetector.Abstractions.Services;
using FaceDetector.Domain.Models.Entities;
using FaceDetector.Dtos;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

namespace FaceDetector.Services.Abstract
{
    public interface IFaceService : IBaseModelService<FaceAppImage, FaceAppImageDto>
    {
        Task<IList<DetectedFace>> DetectFaces(string imageBase64);

        Task<string> CheckAzureService(string apiKey, string path = null);
    }
}
