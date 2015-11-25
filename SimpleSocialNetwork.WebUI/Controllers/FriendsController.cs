using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleSocialNetwork.WebUI.Authentication.Abstract;
using SimpleSocialNetwork.WebUI.ViewModels;
using SimpleSocialNetwork.Domain.Interfaces;
using SimpleSocialNetwork.Domain;
using AutoMapper;
using SimpleSocialNetwork.Domain.BL;

namespace SimpleSocialNetwork.WebUI.Controllers
{
    [Authorize(Roles = "ApprovedMember")] 
    public class FriendsController : Controller
    {
        private readonly IAuthProvider _authProvider;
        private readonly IFriendService _friendService;

        public FriendsController(IAuthProvider authProvider, IFriendService friendService) 
        {
            _friendService = friendService;
            _authProvider = authProvider;
        }
        public ActionResult Index()
        {
            return View(_friendService.GetFriendsByUserId(_authProvider.CurrentUserId).Take(Config.UsersPerPage));
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
