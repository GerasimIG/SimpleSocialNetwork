using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;

namespace SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
        IEnumerable<Message> GetChatHistory(int fromUserId, int toUserId, int quantity);
        IEnumerable<Message> GetConversations(int userId);
    }
}
