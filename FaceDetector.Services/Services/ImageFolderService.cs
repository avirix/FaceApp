using AutoMapper;

using FaceDetector.Abstractions.Repositories;
using FaceDetector.Domain.Database.Repositories.Abstract;
using FaceDetector.Domain.Models.Entities;
using FaceDetector.Dtos;
using FaceDetector.Services.Services.Abstract;

namespace FaceDetector.Services.Services
{
    public class ImageFolderService : BaseModelService<ImageFolder, ImageFolderDto>, IImageFolderService
    {
        public ImageFolderService(IMapper mapper, IImageFolderRepository tRepository)
            : base(mapper, tRepository)
        {
        }
    }
}
