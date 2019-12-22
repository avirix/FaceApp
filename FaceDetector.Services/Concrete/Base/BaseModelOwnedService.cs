using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using FaceDetector.Abstractions.Entities;
using FaceDetector.Abstractions.Repositories;
using FaceDetector.Abstractions.Services;
using FaceDetector.Domain.Models.Common;
using FaceDetector.Services.Helpers;

using Microsoft.AspNetCore.Http;

namespace FaceDetector.Services.Concrete.Base
{
    public class BaseModelOwnedService<T, TDto> : IBaseModelOwnedService<T, TDto>
        where T : CommonModel<Guid>, IUserOwned
    {
        public Guid UserId { get; set; }
        public IMapper Mapper { get; }
        public IBaseRepository<T> Repository { get; }

        protected BaseModelOwnedService(IMapper mapper, IBaseRepository<T> tRepository, IHttpContextAccessor contextAccessor)
        {
            Repository = tRepository;
            Mapper = mapper;
            UserId = UserHelper.GetUserId(contextAccessor);
        }

        public TDto ToDto(T entity) => Mapper.Map<T, TDto>(entity);

        public T ToModel(TDto dto) => Mapper.Map<TDto, T>(dto);

        public virtual TDto Create(TDto TDto)
        {
            var entityT = Mapper.Map<TDto, T>(TDto);

            entityT.Id = Guid.NewGuid();
            entityT.UserId = UserId;

            Repository.Create(entityT);

            return ToDto(Repository.FindById(entityT.Id));
        }

        public virtual void Delete(Guid id)
        {
            var T = Repository.FindById(id);

            if (T is null || T.UserId == UserId)
                throw new FaceAppException($"{typeof(T).Name}, id: {id} don't found");

            Repository.Remove(T);
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            var Ts = Repository.GetAll(x => x.UserId == UserId);
            var TDtoList = new List<TDto>();

            Ts.ToList().ForEach(T => TDtoList.Add(ToDto(T)));
            return TDtoList;
        }

        public virtual TDto GetById(Guid id)
        {
            var T = Repository.FindById(id);

            if (T is null || T.UserId == UserId)
                throw new FaceAppException($"{typeof(T).Name}, id: {id} don't found");

            return ToDto(T);
        }

        public virtual T Update(Guid id, TDto TDto)
        {

            var T = Repository.FindById(id);

            if (T is null || T.UserId == UserId)
                throw new FaceAppException($"{typeof(T).Name}, id: {id} don't found");

            var entityT = Mapper.Map(TDto, T);

            Repository.Update(entityT);

            return T;
        }
    }
}
