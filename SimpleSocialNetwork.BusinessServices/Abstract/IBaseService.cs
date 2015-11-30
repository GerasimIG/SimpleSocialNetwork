using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocialNetwork.BusinessServices
{
    [ServiceContract]
    public interface IBaseService<TEntity> where TEntity : class
    {
        [OperationContract]
        void Add(TEntity entity);
        [OperationContract]
        void Remove(TEntity entity);
        [OperationContract]
        void Update(TEntity entity);
        [OperationContract]
        TEntity GetById(int id);
        [OperationContract]
        IQueryable<TEntity> GetAll();
        void Dispose();
    }
}
