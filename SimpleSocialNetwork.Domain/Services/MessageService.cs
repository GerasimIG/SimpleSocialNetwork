using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain.Interfaces;

namespace SimpleSocialNetwork.Domain.Services
{
    public class MessageService : BaseService<Message>, IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
            : base(messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IEnumerable<Message> GetChatHistory(int fromUserId, int toUserId, int quantity)
        {
            return _messageRepository.GetChatHistory(fromUserId, toUserId, quantity);
        }


        public IEnumerable<Message> GetConversations(int userId)
        {
            return  _messageRepository.GetConversations(userId);
        }
    }
}
