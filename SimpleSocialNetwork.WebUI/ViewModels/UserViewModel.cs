using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleSocialNetwork.Domain;
using System.ComponentModel.DataAnnotations;
using SimpleSocialNetwork.WebUI.PostServiceReference;

namespace SimpleSocialNetwork.WebUI.ViewModels
{
    public enum UserState : byte
    {
        CurrentUser = 0,
        Friend = 1,
        NotFriend = 2,
        Moderator = 3
    }
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        public UserState UserState { get; set; }
        public List<PostDto> Posts { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Birthday {get; set;}
        [Display(Name="Phone")]
        public string PhoneNumber { get; set; }
        public string FullLocation { get; set;}
        public string City { get; set;}
        public string Skype { get; set; }
        public byte[] ImageData { get; set; }
    }
}