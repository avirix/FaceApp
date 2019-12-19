using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

using AutoMapper;

using FaceDetector.Domain.Database.Repositories.Abstract;
using FaceDetector.Domain.Models.Entities;
using FaceDetector.Dtos;
using FaceDetector.Services.Abstract;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.Extensions.Configuration;

namespace FaceDetector.Services.Services
{
    public class FaceService : BaseModelService<FaceAppImage, FaceAppImageDto>, IFaceService
    {
        private readonly IHostingEnvironment _appEnvironment;
        private readonly IFaceClient faceClient;
        private readonly IConfigurationSection faceApiConfig;

        public FaceService(IConfiguration configuration, IMapper mapper, IFaceAppImageRepository faceAppImageRepository,
            IHostingEnvironment hosting)
            : base(mapper, faceAppImageRepository)
        {
            faceApiConfig = configuration.GetSection("FaceApi");
            faceClient = new FaceClient(
                new ApiKeyServiceClientCredentials(faceApiConfig["faceKey"]),
                new DelegatingHandler[] { })
            {
                Endpoint = faceApiConfig["faceEndpoint"]
            };
            _appEnvironment = hosting;
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
                using (var stream = new MemoryStream(bytes))
                {
                    IList<DetectedFace> faceList =
                        await faceClient.Face.DetectWithStreamAsync(
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

        public async Task<string> CheckAzureService(string apiKey, string path = null)
        {
            var testClient = new FaceClient(
                new ApiKeyServiceClientCredentials(apiKey),
                new DelegatingHandler[] { })
            {
                Endpoint = path ?? faceApiConfig["faceEndpoint"]
            };

            FileStream fileStream = new FileStream($"{_appEnvironment.WebRootPath}/test/photo.jpg", FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            using (var memStream = new MemoryStream(binaryReader.ReadBytes((int)fileStream.Length)))
            {
                try
                {
                    IList<DetectedFace> faceList =
                    await testClient.Face.DetectWithStreamAsync(memStream, false, false, new List<FaceAttributeType>());
                }
                catch (Exception)
                {
                    return "Wrong credentials";
                }
            }
            return "Right credentials";
        }
    }
}
