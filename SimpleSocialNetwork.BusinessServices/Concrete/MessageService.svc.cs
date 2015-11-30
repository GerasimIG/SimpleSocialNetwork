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
    public class MessageService : BaseService<Message>, IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService()
        {
            _messageRepository = new MessageRepository();
            _repository = _messageRepository;
        }

        public IEnumerable<Message> GetChatHistory(int fromUserId, int toUserId, int quantity)
        {
            return _messageRepository.GetChatHistory(fromUserId, toUserId, quantity);
        }


        public IEnumerable<Message> GetConversations(int userId)
        {
            return _messageRepository.GetConversations(userId);
        }
    }
}
