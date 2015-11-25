using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SimpleSocialNetwork.WebUI.Authentication.Abstract;
using SimpleSocialNetwork.WebUI.Authorization.Concrete;
using SimpleSocialNetwork.WebUI.ViewModels;
using SimpleSocialNetwork.Domain.Interfaces;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.WebUI.Security.Abstract;
using SimpleSocialNetwork.Domain.BL;


namespace SimpleSocialNetwork.WebUI.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHash _hash;
        public AdminController(IUserService userService,IHash hash)
        {
            _userService = userService;
            _hash = hash;
        }
        public ViewResult Index()
        {
            var moderators = _userService.GetUserByRoleId((int) Roles.Moderator);
            return View(moderators);
        }

        public ViewResult Edit(int userId)
        {
            var user = _userService.GetById(userId);
            var editUser = Mapper.Map<SimpleSocialNetwork.WebUI.ViewModels.EditViewModel>(user);
            return View(editUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = _userService.GetById(model.Id);
                Mapper.Map<EditViewModel, SimpleSocialNetwork.Domain.User>(model, user);
                
                if(!String.IsNullOrWhiteSpace(model.UserPassword) )
                {
                    user.Password = _hash.HashString(model.UserPassword);
                }
                if(_userService.UpdateUser(user))
                {
                    return Redirect(Url.Action("Index", "Admin"));
                }
                ModelState.AddModelError("","Login is already taken");      
            }
            return View();
        }
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = Mapper.Map<SimpleSocialNetwork.Domain.User>(model);
                newUser.RoleId = (int) Roles.Moderator;

                bool result = _userService.CreateUser(newUser);

                if (result)
                {
                    return Redirect(Url.Action("Index", "Admin"));
                }
                else
                ModelState.AddModelError("", "Login is already taken");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int userId)
        {
            var user = _userService.GetById(userId);
            _userService.Remove(user);
            return Redirect(Url.Action("Index", "Admin")); 
        }
    }
}
