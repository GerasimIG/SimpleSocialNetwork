using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleSocialNetwork.WebUI.Authentication.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string userLogin, string userPassword);
        void SignOut();
        int CurrentUserId
        {
            get;
        }

        int CurrentUserRoleId
        {
            get;
        }
    }
}