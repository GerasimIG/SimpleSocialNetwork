using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Concrete;
using AutoMapper;

namespace SimpleSocialNetwork.BusinessServices.Concrete
{
    public class FriendService : BaseService<Friend, FriendDto>, IFriendService
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


        public List<UserDto> GetFriendsByUserId(int userId)
        {
            var result = _friendRepository.GetFriendsByUserId(userId);

            List<UserDto> list = null;

            if (result != null)
            {
                list = new List<UserDto>();
                foreach (var el in result)
                {
                    var friendDto = Mapper.Map<UserDto>(el);
                    list.Add(friendDto);
                }
            }

            return list;
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

            var friendshipDto = Mapper.Map<FriendDto>(friendship);
            if (friendshipDto.Id == 0)
            {
                this.Add(friendshipDto);
            }
        }
    }
}
