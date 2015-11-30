using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract;

namespace SimpleSocialNetwork.Infrastructure.Data.Repositories.Concrete
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public IEnumerable<Post> GetFriendsPostsByUserId(int userId)
        {
            // такий підхід можна застосувати для того, щоб тримати друзів користувача в friendsRepository
            var userFriends = dbContext.Users.Find(userId).Friends.ToList();
            userFriends.AddRange(dbContext.Users.Find(userId).Friends1.ToList());
            
            var userFriendsIds = (from f in userFriends
                                 where f.FirstUserId < userId
                                 select f.FirstUserId).ToList();

            userFriendsIds.AddRange((from f in userFriends
                                 where f.SecondUserId > userId
                                 select f.SecondUserId).ToList()
                );

            var friendsPosts = (from p in dbContext.Posts
                                where userFriendsIds.Contains(p.AuthorId)
                                orderby p.DatePosted descending
                                select p).ToList();
            return friendsPosts;
        }
    }
}
