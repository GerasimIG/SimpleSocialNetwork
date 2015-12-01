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
    public class MessageService : BaseService<Message, MessageDto>, IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService()
        {
            _messageRepository = new MessageRepository();
            _repository = _messageRepository;
        }

        public List<MessageDto> GetChatHistory(int fromUserId, int toUserId, int quantity)
        {
            var result = _messageRepository.GetChatHistory(fromUserId, toUserId, quantity);

            List<MessageDto> list = null;

            if (result != null)
            {
                list = new List<MessageDto>();
                foreach (var el in result)
                {
                    var messageDto = Mapper.Map<MessageDto>(el);
                    list.Add(messageDto);
                }
            }

            return list;
        }


        public List<MessageDto> GetConversations(int userId)
        {
            var result = _messageRepository.GetConversations(userId);

            List<MessageDto> list = null;

            if (result != null)
            {
                list = new List<MessageDto>();
                foreach (var el in result)
                {
                    var messageDto = Mapper.Map<MessageDto>(el);
                    list.Add(messageDto);
                }
            }

            return list;
        }
    }
}
