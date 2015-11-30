using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;

namespace SimpleSocialNetwork.BusinessServices
{
    public interface IMessageService : IBaseService<Message>
    {
        IEnumerable<Message> GetChatHistory(int fromUserId, int toUserId, int quantity);
        IEnumerable<Message> GetConversations(int userId);
    }
}
