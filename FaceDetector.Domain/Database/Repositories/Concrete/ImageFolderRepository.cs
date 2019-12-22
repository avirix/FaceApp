using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceDetector.Domain.Database.Repositories.Abstract;
using FaceDetector.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace FaceDetector.Domain.Database.Repositories.Concrete
{
    public class ImageFolderRepository : BaseRepository<ImageFolder>, IImageFolderRepository
    {
        public ImageFolderRepository(FaceAppDbContext dbContext, IHttpContextAccessor contextAccessor) 
            : base(dbContext, contextAccessor)
        {
        }

        public ImageFolder GetFolderByName(string name)
        {
            return GetAll().FirstOrDefault(x => x.FolderName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
