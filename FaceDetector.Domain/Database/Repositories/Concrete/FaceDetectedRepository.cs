using FaceDetector.Domain.Database.Repositories.Abstract;
using FaceDetector.Domain.Models.Entities;

namespace FaceDetector.Domain.Database.Repositories.Concrete
{
    public class FaceDetectedRepository : BaseRepository<FaceDetected>, IFaceDetectedRepository
    {
        public FaceDetectedRepository(FaceAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
