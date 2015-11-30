using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Domain.Interfaces;

namespace SimpleSocialNetwork.Infrastructure.Data.Repositories.Concrete
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        public IEnumerable<Message> GetChatHistory(int fromUserId, int toUserId, int quantity)
        {
            var chatHistory = (from ch in dbContext.Messages
                               where (ch.FromUserId == fromUserId && ch.ToUserId == toUserId) ||
                                      (ch.FromUserId == toUserId && ch.ToUserId == fromUserId)
                               orderby ch.DateSent descending
                               select ch).Take(quantity);

            return chatHistory;
        }


        public IEnumerable<Message> GetConversations(int userId)
        {
            
            var conversations = (from m in dbContext.Messages
                                 where m.FromUserId == userId || m.ToUserId == userId
                                 let otherId = (m.FromUserId == userId) ? m.ToUserId : m.FromUserId
                                 group m by otherId into g
                                 select g.OrderByDescending(m => m.DateSent).FirstOrDefault()).ToList();
            return conversations.OrderByDescending(item => item.DateSent) ;
        }
    }
}
