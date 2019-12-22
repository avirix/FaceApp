using System;
using System.Collections.Generic;
using System.Text;
using FaceDetector.Abstractions.Repositories;
using FaceDetector.Domain.Models.Entities;

namespace FaceDetector.Domain.Database.Repositories.Abstract
{
    public interface IImagesRepository : IBaseRepository<FaceAppImage>
    {
    }
}
