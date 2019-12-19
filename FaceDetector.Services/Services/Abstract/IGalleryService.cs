using FaceDetector.Abstractions.Services;
using FaceDetector.Domain.Models.Entities;
using FaceDetector.Dtos;

namespace FaceDetector.Services.Abstract
{
    public interface IGalleryService : IBaseModelService<Gallery, GalleryDto>
    {
    }
}
