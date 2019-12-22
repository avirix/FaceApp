using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using FaceDetector.Abstractions.Entities;
using FaceDetector.Abstractions.Repositories;
using FaceDetector.Abstractions.Services;
using FaceDetector.Domain.Models.Common;

namespace FaceDetector.Services.Concrete
{
    public class BaseModelService<T, TDto> : IBaseModelService<T, TDto> where T : CommonModel<Guid>
    {
        public IMapper Mapper { get; }
        public IBaseRepository<T> Repository { get; }

        protected BaseModelService(IMapper mapper, IBaseRepository<T> tRepository)
        {
            Repository = tRepository;
            Mapper = mapper;
        }

        public TDto ToDto(T entity) => Mapper.Map<T, TDto>(entity);

        public T ToModel(TDto dto) => Mapper.Map<TDto, T>(dto);

        public virtual TDto Create(TDto TDto)
        {
            var entityT = Mapper.Map<TDto, T>(TDto);

            entityT.Id = Guid.NewGuid();
            Repository.Create(entityT);

            return ToDto(Repository.FindById(entityT.Id));
        }

        public virtual void Delete(Guid TId)
        {
            var entityT = Repository.FindById(TId);
            Repository.Remove(entityT);
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            var Ts = Repository.GetAll();
            var TDtoList = new List<TDto>();

            Ts.ToList().ForEach(T => TDtoList.Add(ToDto(T)));
            return TDtoList;
        }

        public virtual TDto GetById(Guid id)
        {
            var T = Repository.FindById(id);
            if (T is null)
                throw new FaceAppException($"{typeof(T).Name}, id: {id} don't found");

            return ToDto(T);
        }

        public virtual T Update(Guid id, TDto TDto)
        {

            var T = Repository.FindById(id);

            if (T is null)
                throw new FaceAppException($"{typeof(T).Name}, id: {id} don't found");

            var entityT = Mapper.Map(TDto, T);

            Repository.Update(entityT);

            return T;
        }
    }
}
