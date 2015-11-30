using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;
using System.Web;

namespace SimpleSocialNetwork.BusinessServices
{
    [ServiceContract]
    public interface IUserService : IBaseService<User>
    {
        [OperationContract]
        User GetUserByEmail(string email);
        [OperationContract]
        bool CreateUser(User newUser);
        [OperationContract]
        IEnumerable<User> GetUsersByParams(string userName, string country, string region, string city, int gender, 
            Nullable<DateTime> birthDateFrom, Nullable<DateTime> birthDateTo);
        [OperationContract]
        bool UpdateEmail(string newEmail, int userId);
        [OperationContract]
        bool UpdatePassword(System.Guid newPassword, System.Guid oldPassword, int userId);
        [OperationContract]
        bool UpdateImage(byte[] imageData, string imageMimeType, int userId);
        [OperationContract]
        IEnumerable<User> GetRandomUsers(int quantity);
        [OperationContract]
        IEnumerable<User> GetUserByRoleId(int roleId);
        [OperationContract]
        bool UpdateUser(User user);
    }
}
