using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SimpleSocialNetwork.WebUI.Authentication.Abstract;
using SimpleSocialNetwork.WebUI.ViewModels;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Domain.BL;
using SimpleSocialNetwork.WebUI.UserServiceReference;

namespace SimpleSocialNetwork.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserServiceClient _userService;
        private readonly IAuthProvider _authProvider;
        public AccountController(IAuthProvider authProvider) 
        {
            _userService = new UserServiceClient();
            _authProvider = authProvider;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_authProvider.Authenticate(model.Login, model.Password))
                {
                    switch (_authProvider.CurrentUserRoleId)
                    {
                        case (int) Roles.ApprovedMember:
                            return Redirect(returnUrl ?? Url.Action("Index", "News"));
                        case (int) Roles.Moderator:
                            return RedirectToAction("Index", "Search");
                        case (int) Roles.Administrator:
                            return RedirectToAction("Index", "Admin");
                    }
                }
                ModelState.AddModelError("", "Incorrect Login or Password");
            }
            return View();  
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = Mapper.Map<UserDto> (model);
                newUser.RoleId = (int) Roles.ApprovedMember;

                bool result = _userService.CreateUser(newUser);

                if(result)
                {
                    return Redirect(Url.Action("Login", "Account"));
                }
                ModelState.AddModelError("", "Login is already taken");
            }
            return View();
        }
    }
}
