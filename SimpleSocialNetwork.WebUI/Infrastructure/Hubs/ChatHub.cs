using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SimpleSocialNetwork.WebUI.Authentication.Abstract;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Domain.Services;
using System.Collections.Concurrent;
using SimpleSocialNetwork.Domain.Interfaces;
using SimpleSocialNetwork.WebUI.Authentication.Concrete;
using SimpleSocialNetwork.Infrastructure.Data.Repositories;
using SimpleSocialNetwork.Domain.BL;

namespace SignalRChat
{
    public class MessageDetail
    {

        public string UserName { get; set; }

        public string Message { get; set; }

    }

    public class UserDetail
    {
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
    }
    public class ChatHub : Hub
    {

        private static readonly ConcurrentDictionary<string, string> _users = new ConcurrentDictionary<string, string>();

        private  IAuthProvider _authProvider = new FormsAuthProvider(new UserService(new UserRepository()));
        private  IUserService _userService = new UserService(new UserRepository());
        private  IMessageService _messageService = new MessageService(new MessageRepository());
        
        static List<UserDetail> ConnectedUsers = new List<UserDetail>();
        static List<MessageDetail> CurrentMessage = new List<MessageDetail>();

        public void Connect(string userName, string toDbUserId)
        {
            var id = Context.ConnectionId;


            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                ConnectedUsers.Add(new UserDetail { ConnectionId = id, UserName = userName });

                Clients.Caller.onConnected(id, userName, ConnectedUsers, CurrentMessage);

                Clients.AllExcept(id).onNewUserConnected(id, userName);

                _users[_authProvider.CurrentUserId.ToString()] = id.ToString();

                var chatHistory = _messageService.GetChatHistory(_authProvider.CurrentUserId, Convert.ToInt32(toDbUserId), Config.MessagesHistory);
                chatHistory = chatHistory.Reverse();

                foreach (var item in chatHistory)
                {
                   var us = _userService.GetById(item.FromUserId);
                   Clients.Caller.sendPrivateMessage(id.ToString(), us.FirstName, item.MsgText);
                }
            }
        }
        public void SendPrivateMessage(string toUserId, string message)
        {
            var user = _userService.GetById(Convert.ToInt32(toUserId));

            int toUserDbId = Convert.ToInt32(toUserId);
            try
            {
                toUserId = _users[toUserId];
            }
            catch (KeyNotFoundException)
            {
                toUserId = string.Empty;
            }

            string fromUserId = Context.ConnectionId;

            var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);


            if (toUser != null && fromUser != null)
            {
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message);
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message);
                _dbSave(message, toUserDbId);
            }
            else
            {
                if (toUserDbId != 0 && fromUser != null)
                {
                    _dbSave(message, toUserDbId);
                    Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message);
                }
            }
        }

        private void _dbSave(string message, int toUserDbId)
        {
            var msg = new Message();
            msg.FromUserId = _authProvider.CurrentUserId;
            msg.ToUserId = toUserDbId;
            msg.DateSent = DateTime.Now;
            msg.MsgText = message;
            _messageService.Add(msg);
        }

        public override System.Threading.Tasks.Task OnDisconnected()
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);

            }
            return base.OnDisconnected();
        }
        
    }
}