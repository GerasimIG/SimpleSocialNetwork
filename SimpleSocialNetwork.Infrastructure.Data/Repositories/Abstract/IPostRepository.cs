using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;

namespace SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        IEnumerable<Post> GetFriendsPostsByUserId(int userId);
        IEnumerable<Post> GetPosts(int authorId);
    }
}
