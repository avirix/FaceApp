using FaceDetector.Abstractions.Services;
using FaceDetector.Domain.Models.Entities;
using FaceDetector.Dtos;

namespace FaceDetector.Services.Services.Abstract
{
    public interface IImageFolderService : IBaseModelService<ImageFolder, ImageFolderDto>
    {
    }
}
