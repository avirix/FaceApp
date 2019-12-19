using FaceDetector.Domain.Database.Repositories.Abstract;
using FaceDetector.Domain.Models.Entities;

namespace FaceDetector.Domain.Database.Repositories.Concrete
{
    public class GalleryRepository : BaseRepository<Gallery>, IGalleryRepository
    {
        public GalleryRepository(FaceAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
