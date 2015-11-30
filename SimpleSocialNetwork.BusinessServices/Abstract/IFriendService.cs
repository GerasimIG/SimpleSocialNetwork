using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;

namespace SimpleSocialNetwork.BusinessServices
{
    [ServiceContract]
    public interface IFriendService : IBaseService<Friend>
    {
        [OperationContract]
        bool IsFriends(int firstUserId, int secondUserId);
        [OperationContract]
        IEnumerable<User> GetFriendsByUserId(int userId);
        [OperationContract]
        void RemoveFriendship(int firstUserId, int secondUserId);
        [OperationContract]
        void AddFriendship(int firstUserId, int secondUserId);
    }
}
