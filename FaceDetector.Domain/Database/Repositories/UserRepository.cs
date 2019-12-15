using FaceDetector.Abstractions.Entities;
using FaceDetector.Abstractions.Repositories;

namespace FaceDetector.Domain.Database.Repositories
{
    public class UserRepository : BaseRepository<BaseUser>, IUserRepository
    {
        public UserRepository(FaceAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
