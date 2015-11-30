using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain.Interfaces;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract;

namespace SimpleSocialNetwork.BusinessServices
{
    public class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        protected IBaseRepository<TEntity> _repository;

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
