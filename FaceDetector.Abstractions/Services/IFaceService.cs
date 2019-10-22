using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

namespace FaceDetector.Abstractions.Services
{
    public interface IFaceService
    {
        Task<IList<DetectedFace>> DetectFaces(string imageBase64);
    }
}
