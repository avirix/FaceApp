using FaceDetector.Abstractions.Repositories;
using FaceDetector.Domain.Models.Entities;

namespace FaceDetector.Domain.Database.Repositories.Abstract
{
    public interface IImageFolderRepository : IBaseRepository<ImageFolder>
    {
        ImageFolder GetFolderByName(string name);
    }
}
