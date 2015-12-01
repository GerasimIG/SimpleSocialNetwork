using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Concrete;
using AutoMapper;

namespace SimpleSocialNetwork.BusinessServices.Concrete
{
    public class UserService : BaseService<User, UserDto>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
            _repository = _userRepository;
        }

        public UserDto GetUserByEmail(string email)
        {
            var entity = _userRepository.GetUserByEmail(email);
            var entityDto = Mapper.Map<UserDto>(entity);
            return entityDto;
        }
        public bool CreateUser(UserDto newUser)
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


        public List<UserDto> GetUsersByParams(string userName, string country, string region,
            string city, int gender, Nullable<DateTime> birthDateFrom, Nullable<DateTime> birthDateTo)
        {
            var result = _userRepository.GetUsersByParams(userName, country, region, city, gender, birthDateFrom, birthDateTo);

            List<UserDto> list = null;

            if (result != null)
            {
                list = new List<UserDto>();
                foreach (var el in result)
                {
                    var userDto = Mapper.Map<UserDto>(el);
                    list.Add(userDto);
                }
            }

            return list;
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
        public List<UserDto> GetRandomUsers(int quantity)
        {
            var result = _userRepository.GetRandomUsers(quantity);

            List<UserDto> list = null;

            if (result != null)
            {
                list = new List<UserDto>();
                foreach (var el in result)
                {
                    var userDto = Mapper.Map<UserDto>(el);
                    list.Add(userDto);
                }
            }

            return list;
        }


        public List<UserDto> GetUserByRoleId(int roleId)
        {
            var result = _userRepository.GetUsersByRoleId(roleId);

            List<UserDto> list = null;

            if (result != null)
            {
                list = new List<UserDto>();
                foreach (var el in result)
                {
                    var userDto = Mapper.Map<UserDto>(el);
                    list.Add(userDto);
                }
            }

            return list;
        }


        public bool UpdateUser(UserDto userDto)
        {
            var user = Mapper.Map<User>(userDto);
            return _userRepository.UpdateUser(user);
        }
    }
}
