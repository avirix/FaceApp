using FaceDetector.Domain.Database.Repositories.Abstract;
using FaceDetector.Domain.Models.Entities;

namespace FaceDetector.Domain.Database.Repositories.Concrete
{
    public class ImageFolderRepository : BaseRepository<ImageFolder>, IImageFolderRepository
    {
        public ImageFolderRepository(FaceAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
