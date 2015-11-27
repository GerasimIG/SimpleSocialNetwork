using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SimpleSocialNetwork.WebUI.Authentication.Abstract;
using SimpleSocialNetwork.WebUI.Security.Abstract;
using SimpleSocialNetwork.WebUI.Security.Concrete;
using SimpleSocialNetwork.Domain.Interfaces;

namespace SimpleSocialNetwork.WebUI.Authentication.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        private readonly IHash _hash;
        private readonly IUserService _appUserService;
        private int _currentUserRoleId;
        public FormsAuthProvider(IUserService appUserService)
        {
            _hash = new MD5Hash();
            _appUserService = appUserService;
        }
        public bool Authenticate(string userLogin, string userPassword)
        {
            var user = _appUserService.GetUserByEmail(userLogin);
            
            if (user != null)
            {
                System.Guid hashedPassword = _hash.HashString(userPassword);
                if (hashedPassword == user.Password)
                {
                    FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                    _currentUserRoleId = user.Role.Id;
                    _appUserService.Dispose();
                    return true;
                }
                return false;
            }
            return false;
        }
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public int CurrentUserId
        {
            get { return Convert.ToInt32(HttpContext.Current.User.Identity.Name); }
        }
        public int CurrentUserRoleId
        {
            get { return _currentUserRoleId; }
        }
    }
}