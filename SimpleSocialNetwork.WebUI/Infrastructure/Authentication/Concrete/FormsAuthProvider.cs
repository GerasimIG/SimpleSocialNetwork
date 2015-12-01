using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SimpleSocialNetwork.WebUI.Authentication.Abstract;
using SimpleSocialNetwork.WebUI.Security.Abstract;
using SimpleSocialNetwork.WebUI.Security.Concrete;
using SimpleSocialNetwork.WebUI.UserServiceReference;

namespace SimpleSocialNetwork.WebUI.Authentication.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        private readonly IHash _hash;
        private readonly UserServiceClient _appUserService;
        private int _currentUserRoleId;
        public FormsAuthProvider()
        {
            _hash = new MD5Hash();
            _appUserService = new UserServiceClient();
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
                    _currentUserRoleId = user.RoleId;
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