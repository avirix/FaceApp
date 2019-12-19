using System.Threading.Tasks;

using FaceDetector.Domain.Models.Request;
using FaceDetector.Services.Abstract;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FaceDetector.Controllers
{
    // for admin role only
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FaceServiceController : ControllerBase
    {
        IFaceService faceService;

        public FaceServiceController(IFaceService faceService)
        {
            this.faceService = faceService;
        }

        [HttpPost]
        public async Task<string> AnalyzePicture(ApiCredentials apiCredentials)
        {
            return await faceService.CheckAzureService(apiCredentials.Key, apiCredentials.Url);
        }
    }
}
