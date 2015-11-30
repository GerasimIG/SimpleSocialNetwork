using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;

namespace SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserByEmail(string email);
        IEnumerable<User> GetUsersByParams(string userName, string country, string region, 
            string city, int gender, Nullable<DateTime> birthDateFrom, Nullable<DateTime> birthDateTo);
        IEnumerable<User> GetUsersByRoleId(int roleId);
        IEnumerable<User> GetRandomUsers(int quantity);
        bool UpdateUser(User user);
    }
}
