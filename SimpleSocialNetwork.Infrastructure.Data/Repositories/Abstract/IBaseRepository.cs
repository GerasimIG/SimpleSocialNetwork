using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        void Dispose();
    }
}
