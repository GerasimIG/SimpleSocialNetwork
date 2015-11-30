using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;

namespace SimpleSocialNetwork.BusinessServices
{
    [ServiceContract]
    public interface IMessageService : IBaseService<Message>
    {
        [OperationContract]
        IEnumerable<Message> GetChatHistory(int fromUserId, int toUserId, int quantity);
        [OperationContract]
        IEnumerable<Message> GetConversations(int userId);
    }
}
