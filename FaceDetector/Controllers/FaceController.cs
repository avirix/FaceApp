using System.Collections.Generic;
using System.Threading.Tasks;

using FaceDetector.Domain.Models.Request;
using FaceDetector.Services.Abstract;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

namespace FaceDetector.Controllers
{
    /// <summary>
    /// Main controller for check faces
    /// </summary>
    [Route("api/[controller]")]
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