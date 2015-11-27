using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain.Interfaces;

namespace SimpleSocialNetwork.Domain.Services
{
    public class FriendService : BaseService<Friend>, IFriendService
    {
        private readonly IFriendRepository _friendRepository;
        public FriendService(IFriendRepository friendRepository)
            : base(friendRepository)
        {
            _friendRepository = friendRepository;
        }
        public bool IsFriends(int firstUserId, int secondUserId)
        {
            var friendship = _friendRepository.Get(firstUserId, secondUserId);
            return friendship != null;
        }


        public IEnumerable<User> GetFriendsByUserId(int userId)
        {
            return _friendRepository.GetFriendsByUserId(userId);
        }


        public void RemoveFriendship(int firstUserId, int secondUserId)
        {
            _friendRepository.RemoveFriendship(firstUserId, secondUserId);
        }


        public void AddFriendship(int firstUserId, int secondUserId)
        {
            // в базі значення FirstUserId завжди має бути менше за SecondUserId для уникнення повторення записів
            if (firstUserId > secondUserId)
            {
                int tmp = firstUserId;
                firstUserId = secondUserId;
                secondUserId = tmp;
            }

            var friendship = new Friend();
            friendship.FirstUserId = firstUserId;
            friendship.SecondUserId = secondUserId;
            if (friendship.Id == 0)
            {
                this.Add(friendship);
            }           
        }
    }
}
