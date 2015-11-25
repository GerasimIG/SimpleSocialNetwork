using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocialNetwork.Domain.Interfaces
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        IEnumerable<Post> GetFriendsPostsByUserId(int userId);
    }
}
