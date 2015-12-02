using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;
using System.Web;
using System.Runtime.Serialization;

namespace SimpleSocialNetwork.BusinessServices
{
    [ServiceContract]
    public interface IUserService : IBaseService<User, UserDto>
    {
        [OperationContract]
        UserDto GetUserByEmail(string email);
        [OperationContract]
        bool CreateUser(UserDto newUser);
        [OperationContract]
        List<UserDto> GetUsersByParams(string userName, string country, string region, string city, int gender, 
            Nullable<DateTime> birthDateFrom, Nullable<DateTime> birthDateTo);
        [OperationContract]
        bool UpdateEmail(string newEmail, int userId);
        [OperationContract]
        bool UpdatePassword(System.Guid newPassword, System.Guid oldPassword, int userId);
        [OperationContract]
        bool UpdateImage(byte[] imageData, string imageMimeType, int userId);
        [OperationContract]
        List<UserDto> GetRandomUsers(int quantity);
        [OperationContract]
        List<UserDto> GetUserByRoleId(int roleId);
        [OperationContract]
        bool UpdateUser(UserDto user);
    }

    [DataContract]
    public class UserDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public System.Guid Password { get; set; }
        [DataMember]
        public byte[] ImageData { get; set; }
        [DataMember]
        public string ImageMimeType { get; set; }
        [DataMember]
        public Nullable<int> LocationId { get; set; }
        [DataMember]
        public byte Gender { get; set; }
        [DataMember]
        public Nullable<System.DateTime> Birthday { get; set; }
        [DataMember]
        public string Skype { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public int RoleId { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public string FullLocation { get; set; }
    }
}
