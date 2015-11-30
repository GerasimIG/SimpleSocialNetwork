using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleSocialNetwork.WebUI.Authentication.Abstract;
using SimpleSocialNetwork.WebUI.ViewModels;
using SimpleSocialNetwork.Domain;
using AutoMapper;
using SimpleSocialNetwork.BusinessServices;
using SimpleSocialNetwork.WebUI.Authorization.Concrete;
using SimpleSocialNetwork.Domain.BL;

namespace SimpleSocialNetwork.WebUI.Controllers
{
     
    public class UserController : Controller
    {   
        private readonly IUserService _userService;
        private readonly IAuthProvider _authProvider;
        private readonly IFriendService _friendService;
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        public UserController(IAuthProvider authProvider, IUserService userService, IFriendService friendService, 
            IPostService postService, ICommentService commentService) 
        {
            _postService = postService;
            _friendService = friendService;
            _userService = userService;
            _authProvider = authProvider;
            _commentService = commentService;
        }
        [Authorize(Roles = "ApprovedMember,Moderator")] 
        public ActionResult UserProfile(int? id)
        {
            int userId = id ?? _authProvider.CurrentUserId;
            var user = _userService.GetById(userId);

            if (user != null && user.Role.Id == (int) Roles.ApprovedMember)
            {
                var viewUser = Mapper.Map<SimpleSocialNetwork.WebUI.ViewModels.UserViewModel>(user);
                viewUser.UserState = UserState.CurrentUser;

                if (userId != _authProvider.CurrentUserId)
                {
                    viewUser.UserState = _friendService.IsFriends(userId, _authProvider.CurrentUserId) ? UserState.Friend
                        : UserState.NotFriend;
                }
                return View(viewUser);
            }
            Response.StatusCode = 404;
            return View("NotFound");
        }

        [Authorize(Roles = "ApprovedMember,Moderator")] 
        public FileContentResult GetUserImage(int userId)
        {
            try
            {
                var user = userId != 0 ? _userService.GetById(userId) : _userService.GetById(_authProvider.CurrentUserId);

            
                if (user != null)
                {
                    return File(user.ImageData, user.ImageMimeType);
                } 
                return null;               
            }
            catch(Exception)
            {
                return null;
            }
        }

        [HttpPost]
        [Authorize(Roles = "ApprovedMember")] 
        public ActionResult AddPost(string message)
        { 
            var newPost = new Post();
            newPost.Message = message;
            newPost.AuthorId = _authProvider.CurrentUserId;
            newPost.DatePosted = DateTime.Now;
            _postService.Add(newPost);


            var userPosts = _userService.GetById(_authProvider.CurrentUserId).Posts.Take(Config.PostsPerPage).ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("UserPostsPartial", userPosts);
            }

            return View("UserPostsPartial", userPosts);
        }
        [Authorize(Roles="ApprovedMember,Moderator")] 
        public ActionResult GetPostComments(int postId)
        {        
            var postCommentsViewModel = new PostCommentsViewModel();
            postCommentsViewModel.PostComments = _postService.GetById(postId).Comments.Take(Config.CommentsPerPage).ToList();
            postCommentsViewModel.PostId = postId;

            if (Request.IsAjaxRequest())
            {              
                return PartialView("PostCommentsPartial", postCommentsViewModel);
            }
            return View("PostCommentsPartial", postCommentsViewModel);
        }

        [HttpPost]
        [Authorize(Roles="ApprovedMember")] 
        public ActionResult AddComment(string commentMessage, int postId)
        {
            //  можливо краще використати авто-маппер
            var newComment = new Comment();
            newComment.Message = commentMessage;
            newComment.AuthorId = _authProvider.CurrentUserId;
            newComment.DatePosted = DateTime.Now;
            newComment.PostId = postId;
            _commentService.Add(newComment);

            var postCommentsViewModel = new PostCommentsViewModel();
            postCommentsViewModel.PostComments = _postService.GetById(postId).Comments.Take(Config.CommentsPerPage).ToList();
            postCommentsViewModel.PostId = postId;

            if (Request.IsAjaxRequest())
            {
                return PartialView("PostCommentsPartial", postCommentsViewModel);
            }
            return View("PostCommentsPartial", postCommentsViewModel);
        }
        [Authorize] 
        public ActionResult SignOut()
        {
            _authProvider.SignOut();
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        [Authorize(Roles="ApprovedMember,Moderator")] 
        public ActionResult RemoveComment(int commentId)
        {
            var comment = _commentService.GetById(commentId);
            int postId = comment.PostId;

            _commentService.Remove(comment);

            var postCommentsViewModel = new PostCommentsViewModel();
            postCommentsViewModel.PostComments = _postService.GetById(postId).Comments.Take(Config.CommentsPerPage).ToList();
            postCommentsViewModel.PostId = postId;

            if (Request.IsAjaxRequest())
            {
                return PartialView("PostCommentsPartial", postCommentsViewModel);
            }
            return View("PostCommentsPartial", postCommentsViewModel);
        }

        [HttpPost]
        [Authorize(Roles="ApprovedMember,Moderator")] 
        public ActionResult RemovePost(int postId)
        {
            var post = _postService.GetById(postId);
            int userId = post.AuthorId;
            _postService.Remove(post);
            

            var userPosts = _userService.GetById(userId).Posts.Take(Config.PostsPerPage).ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("UserPostsPartial", userPosts);
            }

            return RedirectToAction("UserPostsPartial", userPosts);
        }
    }
}
