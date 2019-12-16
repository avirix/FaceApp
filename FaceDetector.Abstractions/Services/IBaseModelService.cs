using System;
using System.Collections.Generic;

using AutoMapper;

using FaceDetector.Abstractions.Entities;
using FaceDetector.Abstractions.Repositories;

namespace FaceDetector.Abstractions.Services
{
    public interface IBaseModelService<T, TDto> where T : CommonModel<Guid>
    {
        IMapper Mapper { get; }
        IBaseRepository<T> Repository { get; }

        TDto ToDto(T entity);

        T ToModel(TDto dto);

        TDto Create(TDto TDto);

        void Delete(Guid TId);

        IEnumerable<TDto> GetAll();

        TDto GetById(Guid id);

        T Update(Guid id, TDto TDto);
    }
}
