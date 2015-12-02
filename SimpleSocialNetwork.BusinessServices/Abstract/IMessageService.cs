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
    public interface IMessageService : IBaseService<Message, MessageDto>
    {
        [OperationContract]
        List<MessageDto> GetChatHistory(int fromUserId, int toUserId, int quantity);
        [OperationContract]
        List<MessageDto> GetConversations(int userId);
    }

    [DataContract]
    public class MessageDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int FromUserId { get; set; }
        [DataMember]
        public int ToUserId { get; set; }
        [DataMember]
        public string MsgText { get; set; }
        [DataMember]
        public System.DateTime DateSent { get; set; }
    }
}
