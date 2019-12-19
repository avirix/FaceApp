using System;
using System.Collections.Generic;

using FaceDetector.Abstractions.Entities;

namespace FaceDetector.Abstractions.Repositories
{
    public interface IBaseRepository<T> where T : CommonModel<Guid>
    {
        void Create(T item);
        T FindById(Guid id);
        IEnumerable<T> GetAll(bool noTracking = false);
        IEnumerable<T> GetAll(Func<T, bool> predicate);
        IEnumerable<T> Get(Func<T, bool> predicate);
        void Remove(T item);
        void Update(T item);
    }
}
