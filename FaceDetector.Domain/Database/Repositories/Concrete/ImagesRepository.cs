using FaceDetector.Domain.Database.Repositories.Abstract;
using FaceDetector.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace FaceDetector.Domain.Database.Repositories.Concrete
{
    public class ImagesRepository : BaseRepository<FaceAppImage>, IImagesRepository
    {
        public ImagesRepository(FaceAppDbContext dbContext, IHttpContextAccessor contextAccessor) 
            : base(dbContext, contextAccessor)
        {
        }
    }
}
