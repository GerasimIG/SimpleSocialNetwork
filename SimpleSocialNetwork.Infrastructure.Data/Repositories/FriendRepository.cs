using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Domain.Interfaces;

namespace SimpleSocialNetwork.Infrastructure.Data.Repositories
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
                    var currFriend = (from user in dbContext.Users
                                      where user.Id == currFriendId
                                      select user).FirstOrDefault();
                    userFriends.Add(currFriend);
                }

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
