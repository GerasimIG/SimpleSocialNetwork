using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleSocialNetwork.WebUI.Authentication.Abstract;
using SimpleSocialNetwork.WebUI.ViewModels;
using SimpleSocialNetwork.Domain;
using AutoMapper;
using SimpleSocialNetwork.Domain.BL;
using SimpleSocialNetwork.WebUI.FriendServiceReference;
using SimpleSocialNetwork.WebUI.UserServiceReference;

namespace SimpleSocialNetwork.WebUI.Controllers
{
    [Authorize(Roles = "ApprovedMember")] 
    public class FriendsController : Controller
    {
        private readonly IAuthProvider _authProvider;
        private readonly FriendServiceClient _friendService;

        public FriendsController(IAuthProvider authProvider) 
        {
            _friendService = new FriendServiceClient();
            _authProvider = authProvider;
        }
        public ActionResult Index()
        {
            var result = _friendService.GetFriendsByUserId(_authProvider.CurrentUserId).Take(Config.UsersPerPage).ToList();
            var viewModel = Mapper.Map< List<FriendServiceReference.UserDto>, List<UserServiceReference.UserDto>>(result);
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult RemoveFriend(UserViewModel model)
        {
            _friendService.RemoveFriendship(_authProvider.CurrentUserId, model.Id);

            return RedirectToAction("UserProfile", "User");
        }

        [HttpPost]
        public ActionResult AddFriend(UserViewModel model)
        {
            _friendService.AddFriendship(_authProvider.CurrentUserId, model.Id);

            return RedirectToAction("UserProfile", "User");
        }
    }
}
