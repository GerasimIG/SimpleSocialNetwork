using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;
using System.Web;

namespace SimpleSocialNetwork.Domain.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        User GetUserByEmail(string email);
        bool CreateUser(User newUser);
        IEnumerable<User> GetUsersByParams(string userName, string country, string region, string city, int gender, 
            Nullable<DateTime> birthDateFrom, Nullable<DateTime> birthDateTo);
        bool UpdateEmail(string newEmail, int userId);
        bool UpdatePassword(System.Guid newPassword, System.Guid oldPassword, int userId);
        bool UpdateImage(byte[] imageData, string imageMimeType, int userId);
        IEnumerable<User> GetRandomUsers(int quantity);
        IEnumerable<User> GetUserByRoleId(int roleId);
        bool UpdateUser(User user);
    }
}
