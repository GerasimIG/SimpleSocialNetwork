using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Concrete;

namespace SimpleSocialNetwork.BusinessServices.Concrete
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
            _repository = _userRepository;
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }
        public bool CreateUser(User newUser)
        {
            var user = _userRepository.GetUserByEmail(newUser.Email);
            if (user == null)
            {
                if (newUser.Id == 0)
                {
                    this.Add(newUser);
                    return true;
                }
                return false;
            }
            return false;
        }


        public IEnumerable<User> GetUsersByParams(string userName, string country, string region,
            string city, int gender, Nullable<DateTime> birthDateFrom, Nullable<DateTime> birthDateTo)
        {
            return _userRepository.GetUsersByParams(userName, country, region, city, gender, birthDateFrom, birthDateTo);
        }


        public bool UpdateEmail(string newEmail, int userId)
        {
            var user = _userRepository.GetUserByEmail(newEmail);
            if (user == null)
            {
                var userToUpdate = _userRepository.GetById(userId);
                userToUpdate.Email = newEmail;
                _userRepository.Update(userToUpdate);
                return true;
            }
            return false;
        }
        public bool UpdatePassword(Guid newPassword, Guid oldPassword, int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user.Password == oldPassword)
            {
                user.Password = newPassword;
                _userRepository.Update(user);
            }
            return false;
        }


        public bool UpdateImage(byte[] imageData, string imageMimeType, int userId)
        {
            if (imageMimeType == "image/jpeg" || imageMimeType == "image/png" || imageMimeType == "image/gif")
            {
                var user = _userRepository.GetById(userId);
                user.ImageMimeType = imageMimeType;
                user.ImageData = imageData;
                _userRepository.Update(user);
                return true;
            }
            return false;
        }
        public IEnumerable<User> GetRandomUsers(int quantity)
        {
            return _userRepository.GetRandomUsers(quantity);
        }


        public IEnumerable<User> GetUserByRoleId(int roleId)
        {
            return _userRepository.GetUsersByRoleId(roleId);
        }


        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
    }
}
