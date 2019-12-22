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
using FaceDetector.Services.Concrete.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.Extensions.Configuration;

namespace FaceDetector.Services.Concrete
{
    public class FaceService : BaseModelOwnedService<FaceAppImage, ImageDto>, IFaceService
    {
        public IFaceClient FaceClient { get; set; }

        public FaceService(IMapper mapper, IImagesRepository tRepository, IConfiguration configuration, IHttpContextAccessor contextAccessor)
            : base(mapper, tRepository, contextAccessor)
        {
            var faceApiConfig = configuration.GetSection("FaceApi");
            FaceClient = new FaceClient(
                new ApiKeyServiceClientCredentials(faceApiConfig["faceKey"]),

            new DelegatingHandler[] { })
            {
                Endpoint = faceApiConfig["faceEndpoint"]
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
                using (var stream = new MemoryStream(bytes))
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
