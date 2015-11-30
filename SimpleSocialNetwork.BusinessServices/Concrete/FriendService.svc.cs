using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Concrete;

namespace SimpleSocialNetwork.BusinessServices.Concrete
{
    public class FriendService : BaseService<Friend>, IFriendService
    {
        private readonly IFriendRepository _friendRepository;
        public FriendService()
        {
            _friendRepository = new FriendRepository();
            _repository = _friendRepository;
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
