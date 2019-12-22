using System;

using FaceDetector.Abstractions.Entities;

namespace FaceDetector.Abstractions.Services
{
    public interface IBaseModelOwnedService<T, TDto> : IBaseModelService<T, TDto> where T : CommonModel<Guid>, IUserOwned
    {
    }
}
