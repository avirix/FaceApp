using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

using FaceDetector.Abstractions.Services;

using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.Extensions.Configuration;

namespace FaceDetector.Services.Services
{
    public class FaceService : IFaceService
    {
        public IConfiguration Configuration { get; }
        public IFaceClient FaceClient { get; set; }

        public FaceService(IConfiguration configuration)
        {
            Configuration = configuration;
            FaceClient = new FaceClient(
                new ApiKeyServiceClientCredentials(Configuration["FaceApi:faceKey"]),
                new DelegatingHandler[] { })
            {
                Endpoint = Configuration["FaceApi:faceEndpoint"]
            };
        }

        public async Task<IList<DetectedFace>> DetectFaces(string imageBase64)
        {
            IList<FaceAttributeType> faceAttributes =
                new FaceAttributeType[]
                {
                    FaceAttributeType.Gender, FaceAttributeType.Age,
                    FaceAttributeType.Smile, FaceAttributeType.Emotion,
                    FaceAttributeType.Glasses, FaceAttributeType.Hair
                };

            try
            {
                var bytes = Convert.FromBase64String(imageBase64.Substring(imageBase64.LastIndexOf(',') + 1));
                using (var stream = new MemoryStream(bytes)) // File.OpenRead("photo1.jpg"))
                {
                    IList<DetectedFace> faceList =
                        await FaceClient.Face.DetectWithStreamAsync(
                        stream, true, true, faceAttributes);
                    return faceList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<DetectedFace>();
            }
        }
    }
}
