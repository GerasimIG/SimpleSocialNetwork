using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleSocialNetwork.WebUI.Authentication.Concrete;
using SimpleSocialNetwork.WebUI.Authentication.Abstract;
using SimpleSocialNetwork.Infrastructure.Data.Repositories;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Concrete;
using SimpleSocialNetwork.WebUI.UserServiceReference;

namespace SimpleSocialNetwork.WebUI.Authorization.Concrete
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private IAuthProvider _authProvider = new FormsAuthProvider();
        private UserServiceClient _userService = new UserServiceClient();

        private readonly string[] _allowedRoles;
        public CustomAuthorizeAttribute(params string[] allowedRoles)
        {
            _allowedRoles = allowedRoles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            foreach (var role in _allowedRoles)
            {
                string userRole = string.Empty;
                try
                {
                    userRole = _userService.GetById(_authProvider.CurrentUserId).RoleName;
                }
                catch(FormatException)
                {
                    return false;
                }

                if (role == userRole)
                {
                    authorize = true;
                }
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    } 
}