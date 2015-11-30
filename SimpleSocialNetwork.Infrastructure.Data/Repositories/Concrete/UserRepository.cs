using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Domain.Interfaces;
using SimpleSocialNetwork.Domain.BL;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract;

namespace SimpleSocialNetwork.Infrastructure.Data.Repositories.Concrete
{
    public class UserRepository : BaseRepository<User>, IUserRepository 
    {
        public User GetUserByEmail(string email)
        {
            var user = (from u in dbContext.Users
                        where u.Email == email
                        select u).FirstOrDefault();
            return user;
        }
        public IEnumerable<User> GetUsersByParams(string userName, string country,
            string region, string city, int gender, Nullable<DateTime> birthDateFrom, Nullable<DateTime> birthDateTo)
        {
            IEnumerable<User> users = new List<User>();

            string userNameFirstParam = string.Empty;
            string userNameSecondParam = string.Empty;

            if (!String.IsNullOrWhiteSpace(userName))
            {
                string[] userNameArr = userName.Split(new Char[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);

                userNameFirstParam = userNameArr[0];
 
                if (userNameArr.Length == 2)
                {
                    userNameSecondParam = userNameArr[1];
                }
            }
            else
            {
                userName = String.Empty;
            }

            users = (from user in dbContext.Users
                     where 
                     (birthDateFrom == null ? true : user.Birthday >birthDateFrom)
                     &&
                     (birthDateTo == null ? true : user.Birthday > birthDateTo)
                     &&
                     (gender == 0 ? true : user.Gender == gender)
                     &&
                     (String.IsNullOrEmpty(country) ? true : user.Location.CountryName == country)
                     &&
                     (String.IsNullOrEmpty(region) ? true : user.Location.RegionName == region)
                     &&
                     (String.IsNullOrEmpty(city) ? true : user.Location.RegionName == city)
                     &&
                     (user.Role.Id == (int) Roles.ApprovedMember)
                     &&
                     (String.IsNullOrEmpty(userName) ?  true :
                         (String.IsNullOrEmpty(userNameSecondParam)
                                      ?
                                      (user.FirstName.ToLower().StartsWith(userNameFirstParam.ToLower())
                                                            || user.LastName.ToLower().StartsWith(userNameFirstParam.ToLower()))
                                      :
                                      (user.FirstName.ToLower().StartsWith(userNameFirstParam.ToLower())
                                                            && user.LastName.ToLower().StartsWith(userNameSecondParam.ToLower()))
                                                            ||
                                      (user.LastName.ToLower().StartsWith(userNameFirstParam.ToLower())
                                                            && user.FirstName.ToLower().StartsWith(userNameSecondParam.ToLower()))
                         )
                      )
                     select user);
            return users;
        }
        public IEnumerable<User> GetRandomUsers(int quantity)
        {
            var randomUsers = (from u in dbContext.Users
                               where u.Role.Id == (int) Roles.ApprovedMember
                               select u).OrderBy(x => Guid.NewGuid()).Take(quantity).ToList();
            return randomUsers;
        }
        public IEnumerable<User> GetUsersByRoleId(int roleId)
        {
            var users = (from u in dbContext.Users
                         where u.RoleId == roleId
                         select u).ToList();
            return users;
        }
        public bool UpdateUser(User user)
        {
            var checkUser = (from u in dbContext.Users
                             where u.Email == user.Email
                             select u).FirstOrDefault();
            if(checkUser == null || checkUser.Email == user.Email)
            {
                this.Update(user);
                return true;
            }
            return false;
        }
    }
}
