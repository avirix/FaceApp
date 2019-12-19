using FaceDetector.Abstractions.Repositories;
using FaceDetector.Domain.Models.Entities;

namespace FaceDetector.Domain.Database.Repositories.Concrete
{
    public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(FaceAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
