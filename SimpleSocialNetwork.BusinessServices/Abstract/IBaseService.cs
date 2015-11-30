using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocialNetwork.BusinessServices
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        void Dispose();
    }
}
