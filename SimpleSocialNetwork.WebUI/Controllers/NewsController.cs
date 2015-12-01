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
using SimpleSocialNetwork.WebUI.PostServiceReference;

namespace SimpleSocialNetwork.WebUI.Controllers
{
    [Authorize(Roles = "ApprovedMember")] 
    public class NewsController : Controller
    {
        private readonly PostServiceClient _postService;
        private readonly IAuthProvider _authProvider;
        public NewsController(IAuthProvider authProvider) 
        {
            _postService = new PostServiceClient();
            _authProvider = authProvider;
        }
        public ViewResult Index()
        {
            var friendsPosts = _postService.GetFriendsPostsByUserId(_authProvider.CurrentUserId).Take(Config.PostsPerPage).ToList();
            return View(friendsPosts);
        }

    }
}
