using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;

namespace SimpleSocialNetwork.BusinessServices
{
    public interface IFriendService : IBaseService<Friend>
    {
        bool IsFriends(int firstUserId, int secondUserId);
        IEnumerable<User> GetFriendsByUserId(int userId);

        void RemoveFriendship(int firstUserId, int secondUserId);

        void AddFriendship(int firstUserId, int secondUserId);
    }
}
