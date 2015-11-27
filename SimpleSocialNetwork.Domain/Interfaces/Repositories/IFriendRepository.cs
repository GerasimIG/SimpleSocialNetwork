using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocialNetwork.Domain.Interfaces
{
    public interface IFriendRepository : IBaseRepository<Friend>
    {
        Friend Get(int firstUserId, int secondUserId);
        IEnumerable<User> GetFriendsByUserId(int userId);
        void RemoveFriendship(int firstUserId, int secondUserId);
    }
}
