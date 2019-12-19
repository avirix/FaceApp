using AutoMapper;

using FaceDetector.Abstractions.Repositories;
using FaceDetector.Domain.Database.Repositories.Abstract;
using FaceDetector.Domain.Models.Entities;
using FaceDetector.Dtos;
using FaceDetector.Services.Services.Abstract;

namespace FaceDetector.Services.Services
{
    public class FaceDetectedService : BaseModelService<FaceDetected, FaceDetectedDto>, IFaceDetectedService
    {
        public FaceDetectedService(IMapper mapper, IFaceDetectedRepository tRepository)
            : base(mapper, tRepository)
        {
        }
    }
}
