using System;
using System.Linq;
using System.Linq.Expressions;

using FaceDetector.Abstractions.Entities;
using FaceDetector.Abstractions.Repositories;

using Microsoft.EntityFrameworkCore;

namespace FaceDetector.Domain.Database.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : CommonModel<Guid>
    {
        private readonly FaceAppDbContext dbContext;
        protected readonly DbSet<T> dbSet;

        protected BaseRepository(FaceAppDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll(bool noTracking = false)
        {
            return noTracking ? dbSet.AsNoTracking() : dbSet;
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public virtual T FindById(Guid id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public virtual void Create(T item)
        {
            dbSet.Add(item);
            dbContext.SaveChanges();
        }

        public virtual void Update(T item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public virtual void Remove(T item)
        {
            dbSet.Remove(item);
            dbContext.SaveChanges();
        }
    }
}
