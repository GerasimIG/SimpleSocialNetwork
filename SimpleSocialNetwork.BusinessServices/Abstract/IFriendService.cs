using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;
using System.Runtime.Serialization;

namespace SimpleSocialNetwork.BusinessServices
{
    [ServiceContract]
    public interface IFriendService : IBaseService<Friend, FriendDto>
    {
        [OperationContract]
        bool IsFriends(int firstUserId, int secondUserId);
        [OperationContract]
        List<UserDto> GetFriendsByUserId(int userId);
        [OperationContract]
        void RemoveFriendship(int firstUserId, int secondUserId);
        [OperationContract]
        void AddFriendship(int firstUserId, int secondUserId);
    }

    [DataContract]
    public class FriendDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int FirstUserId { get; set; }
        [DataMember]
        public int SecondUserId { get; set; }
    }
}
