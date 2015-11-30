using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        IEnumerable<Post> GetFriendsPostsByUserId(int userId);
    }
}
