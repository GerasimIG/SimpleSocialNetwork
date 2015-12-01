using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract;
using AutoMapper;

namespace SimpleSocialNetwork.BusinessServices
{
    public class BaseService<TEntity, TEntityDto> : IDisposable, IBaseService<TEntity, TEntityDto> where TEntity : class
                                                                                                   where TEntityDto : class
    {
        protected IBaseRepository<TEntity> _repository;

        public void Add(TEntityDto entityDto)
        {
            var entity = Mapper.Map<TEntity>(entityDto);
            _repository.Add(entity);
        }

        public void Remove(TEntityDto entityDto)
        {
            var entity = Mapper.Map<TEntity>(entityDto);
            _repository.Remove(entity);
        }

        public void Update(TEntityDto entityDto)
        {
            var entity = Mapper.Map<TEntity>(entityDto);
            _repository.Update(entity);
        }

        public TEntityDto GetById(int id)
        {
            var entity = _repository.GetById(id);
            var entityDto = Mapper.Map<TEntityDto>(entity);
            return entityDto;
        }

        public List<TEntityDto> GetAll()
        {
            var result = _repository.GetAll();

            List<TEntityDto> list = null;

            if (result != null)
            {
                list = new List<TEntityDto>();
                foreach (var el in result)
                {
                    var entityDto = Mapper.Map<TEntityDto>(el);
                    list.Add(entityDto);
                }
            }

            return list;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
