using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocialNetwork.Domain.Interfaces
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
        IEnumerable<Message> GetChatHistory(int fromUserId, int toUserId, int quantity);
        IEnumerable<Message> GetConversations(int userId);
    }
}
