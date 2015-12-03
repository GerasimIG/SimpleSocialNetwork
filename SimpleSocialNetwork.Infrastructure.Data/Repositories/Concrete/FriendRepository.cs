using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract;

namespace SimpleSocialNetwork.Infrastructure.Data.Repositories.Concrete
{
    public class FriendRepository : BaseRepository<Friend>, IFriendRepository
    {
        public Friend Get(int firstUserId, int secondUserId)
        {
            if (firstUserId > secondUserId)
            {
                int tmp = firstUserId;
                firstUserId = secondUserId;
                secondUserId = tmp;
            }

            var result = (from f in dbContext.Friends
                          where f.FirstUserId == firstUserId && f.SecondUserId == secondUserId
                          select f).FirstOrDefault();

            return result;
        }

        public IEnumerable<User> GetFriendsByUserId(int userId)
        {
            //можна придумати оптимальніший запит
            List<User> userFriends = new List<User>();
            List<int> friendsIds = new List<int>();

            foreach (var friendRelation in dbContext.Friends)
            {
                int currFriendId = 0;
                if (friendRelation.FirstUserId == userId)
                {
                    currFriendId = friendRelation.SecondUserId;
                }
                else
                {
                    if (friendRelation.SecondUserId == userId)
                    {
                        currFriendId = friendRelation.FirstUserId;
                    }
                }
                if (currFriendId != 0)
                {
                    friendsIds.Add(currFriendId);
              /*      var currFriend = (from user in dbContext.Users
                                      where user.Id == currFriendId
                                      select user).FirstOrDefault();
                    userFriends.Add(currFriend);*/
                }

            }

            foreach(var id in friendsIds)
            {
                var friend = dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
                userFriends.Add(friend);
            }

            return userFriends;
        }

        //можливо краще передавати в якості параметру об'єкт дружби і використовувати базовий метод
        public void RemoveFriendship(int firstUserId, int secondUserId)
        {
            if (firstUserId > secondUserId)
            {
                int tmp = firstUserId;
                firstUserId = secondUserId;
                secondUserId = tmp;
            }

            var friendship = (from f in dbContext.Friends
                              where f.FirstUserId == firstUserId && f.SecondUserId == secondUserId
                              select f).FirstOrDefault();

            dbContext.Friends.Remove(friendship);
            dbContext.SaveChanges();
        }
    }
}
