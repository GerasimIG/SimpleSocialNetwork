using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocialNetwork.BusinessServices
{
    [ServiceContract]
    public interface IBaseService<TEntity, TEntityDto> where TEntity : class
                                                       where TEntityDto : class
    {
        [OperationContract]
        void Add(TEntityDto entity);
        [OperationContract]
        void Remove(TEntityDto entity);
        [OperationContract]
        void RemoveById(int id);
        [OperationContract]
        void Update(TEntityDto entity);
        [OperationContract]
        TEntityDto GetById(int id);
        [OperationContract]
        List<TEntityDto> GetAll();
        void Dispose();
    }
}
