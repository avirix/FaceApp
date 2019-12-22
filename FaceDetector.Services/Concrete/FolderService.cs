using AutoMapper;

using FaceDetector.Domain.Database.Repositories.Abstract;
using FaceDetector.Domain.Models.Entities;
using FaceDetector.Dtos;
using FaceDetector.Services.Abstract;
using FaceDetector.Services.Concrete.Base;
using Microsoft.AspNetCore.Http;

namespace FaceDetector.Services.Concrete
{
    public class FolderService : BaseModelOwnedService<ImageFolder, FolderDto>, IFolderService
    {
        public FolderService(IMapper mapper, IImageFolderRepository tRepository, IHttpContextAccessor contextAccessor) 
            : base(mapper, tRepository, contextAccessor)
        {
        }
    }
}
