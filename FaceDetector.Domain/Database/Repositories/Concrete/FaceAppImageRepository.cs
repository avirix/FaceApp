using FaceDetector.Domain.Database.Repositories.Abstract;
using FaceDetector.Domain.Models.Entities;

namespace FaceDetector.Domain.Database.Repositories.Concrete
{
    public class FaceAppImageRepository : BaseRepository<FaceAppImage>, IFaceAppImageRepository
    {
        public FaceAppImageRepository(FaceAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
