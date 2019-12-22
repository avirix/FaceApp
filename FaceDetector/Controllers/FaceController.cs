using System.Collections.Generic;
using System.Threading.Tasks;

using FaceDetector.Abstractions.Services;
using FaceDetector.Domain.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

namespace FaceDetector.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class FaceController : ControllerBase
    {
        IFaceService faceService;

        public FaceController(IFaceService faceService)
        {
            this.faceService = faceService;
        }

        [HttpPost]
        public async Task<IList<DetectedFace>> AnalyzePicture([FromBody] FaceImageData imageData)
        {
            return await faceService.DetectFaces(imageData.Image);
        }
    }
}