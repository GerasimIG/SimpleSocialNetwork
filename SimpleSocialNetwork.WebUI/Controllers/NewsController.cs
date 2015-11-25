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
    public class NewsController : Controller
    {
        private readonly IPostService _postService;
        private readonly IAuthProvider _authProvider;
        public NewsController(IPostService postService, IAuthProvider authProvider) 
        {
            _postService = postService;
            _authProvider = authProvider;
        }
        public ViewResult Index()
        {
            var friendsPosts = _postService.GetFriendsPostsByUserId(_authProvider.CurrentUserId).Take(Config.PostsPerPage).ToList();
            return View(friendsPosts);
        }

    }
}
