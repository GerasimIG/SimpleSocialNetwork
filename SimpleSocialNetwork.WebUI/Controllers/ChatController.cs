using System.Collections.Generic;
using System.Web.Mvc;
using SimpleSocialNetwork.WebUI.ViewModels;
using SimpleSocialNetwork.WebUI.Authentication.Abstract;
using SimpleSocialNetwork.Domain.BL;
using SimpleSocialNetwork.WebUI.UserServiceReference;
using SimpleSocialNetwork.WebUI.MessageServiceReference;

namespace SimpleSocialNetwork.WebUI.Controllers
{
    [Authorize(Roles = "ApprovedMember")] 
    public class ChatController : Controller
    {
        private readonly UserServiceClient _userService;
        private readonly IAuthProvider _authProvider;
        private readonly MessageServiceClient _messageService;
        public ChatController(IAuthProvider authProvider) 
        {
            _userService = new UserServiceClient();
            _authProvider = authProvider;
            _messageService = new MessageServiceClient();
        }

        public ActionResult Chat(int toId)
        {
            UserViewModel viewUser = new UserViewModel();


            int userId = _authProvider.CurrentUserId;
            var user = _userService.GetById(userId);
            
            // потрібно реалізувати через авто-маппер
            viewUser.Id = user.Id;
            viewUser.ImageData = user.ImageData;
            viewUser.LastName = user.LastName;
            viewUser.FirstName = user.FirstName;
            viewUser.UserState = UserState.CurrentUser;
            
            //потрібно використати іншу властвість
            viewUser.PhoneNumber = toId.ToString();

            return View("Chat", viewUser);
        }

        public ViewResult Index()
        {
            var userChats = _messageService.GetConversations(_authProvider.CurrentUserId);
            var userChatsViewModel = new List<ChatViewModel>();

            //реалізувати через автомаппер
/*            foreach(var element in userChats)
            {
                var userChat = new ChatViewModel();
             
                userChat.LastMessage = element.MsgText.Length < Config.MessageLength ? element.MsgText : element.MsgText.Substring(0, Config.MessageLength -3) + " ...";
                userChat.ChatWithUserId = element.FromUserId == _authProvider.CurrentUserId ? element.ToUserId : element.FromUserId;
                userChat.LastMessageAuthorName = _userService.GetById(element.FromUserId).FirstName;
                if(element.User1.Id == _authProvider.CurrentUserId)
                {
                    userChat.FirstName = element.User.FirstName;
                    userChat.LastName = element.User.LastName;
                    userChat.ImageData = element.User.ImageData;
                }
                else
                {
                    userChat.FirstName = element.User1.FirstName;
                    userChat.LastName = element.User1.LastName;
                    userChat.ImageData = element.User1.ImageData;
                }
                userChat.DateSent = element.DateSent;
                userChatsViewModel.Add(userChat);
            }
            */
            return View(userChatsViewModel);
        }

    }
}
