using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;

namespace SimpleSocialNetwork.Domain.Interfaces
{
    public interface IPostService : IBaseService<Post>
    {
        IEnumerable<Post> GetFriendsPostsByUserId(int userId);
    }
}
