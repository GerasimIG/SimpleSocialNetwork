using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SimpleSocialNetwork.Domain.Interfaces;
using SimpleSocialNetwork.Domain.Services;
using SimpleSocialNetwork.WebUI.Authentication.Concrete;
using SimpleSocialNetwork.WebUI.Authentication.Abstract;
using  SimpleSocialNetwork.Infrastructure.Data.Repositories;

       
namespace SimpleSocialNetwork.WebUI.Authorization.Concrete
{
    public class CustomRoleProvider : RoleProvider
    {
        private IAuthProvider _authProvider = new FormsAuthProvider(new UserService(new UserRepository()));
        private IUserService _userService = new UserService(new UserRepository());
        
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string userRole = _userService.GetById(Convert.ToInt32(username)).Role.Name;
            return new string[] {userRole};
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}