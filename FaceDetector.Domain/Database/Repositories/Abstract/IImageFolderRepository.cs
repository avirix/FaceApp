using System.Threading.Tasks;
using FaceDetector.Abstractions.Repositories;
using FaceDetector.Domain.Models.Entities;

namespace FaceDetector.Domain.Database.Repositories.Abstract
{
    public interface IImageFolderRepository : IBaseRepository<ImageFolder>
    {
        Task<ImageFolder> GetFolderByName(string name);
    }
}
