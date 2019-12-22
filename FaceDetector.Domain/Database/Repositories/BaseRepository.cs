using System;
using System.Linq;
using System.Linq.Expressions;

using FaceDetector.Abstractions.Entities;
using FaceDetector.Abstractions.Repositories;
using FaceDetector.Services.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FaceDetector.Domain.Database.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : CommonModel<Guid>
    {
        private readonly FaceAppDbContext dbContext;
        protected readonly DbSet<T> dbSet;
        private readonly Guid? UserId; 

        protected BaseRepository(FaceAppDbContext dbContext, IHttpContextAccessor contextAccessor)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
            UserId = UserHelper.GetUserIdNoException(contextAccessor);
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
            item.Created = DateTime.UtcNow;
            item.CreatedId = UserId;
            dbSet.Add(item);
            dbContext.SaveChanges();
        }

        public virtual void Update(T item)
        {
            item.LastUpdated = DateTime.UtcNow;
            item.UpdatedId = UserId;
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
