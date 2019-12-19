using FaceDetector.Abstractions.Repositories;
using FaceDetector.Domain.Models.Entities;

namespace FaceDetector.Domain.Database.Repositories.Abstract
{
    public interface IFaceDetectedRepository : IBaseRepository<FaceDetected>
    {
    }
}
