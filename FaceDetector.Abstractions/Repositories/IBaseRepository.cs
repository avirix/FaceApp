using System;
using System.Linq;
using System.Linq.Expressions;

using FaceDetector.Abstractions.Entities;

namespace FaceDetector.Abstractions.Repositories
{
    public interface IBaseRepository<T> where T : CommonModel<Guid>
    {
        void Create(T item);
        T FindById(Guid id);
        IQueryable<T> GetAll(bool noTracking = false);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        void Remove(T item);
        void Update(T item);
    }
}
