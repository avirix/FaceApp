using FaceDetector.Abstractions.Entities;
using FaceDetector.Abstractions.Repositories;
using Microsoft.AspNetCore.Http;

namespace FaceDetector.Domain.Database.Repositories
{
    public class UserRepository : BaseRepository<BaseUser>, IUserRepository
    {
        public UserRepository(FaceAppDbContext dbContext, IHttpContextAccessor contextAccessor) 
            : base(dbContext, contextAccessor)
        {
        }
    }
}
