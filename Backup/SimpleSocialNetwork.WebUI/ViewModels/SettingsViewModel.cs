using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace SimpleSocialNetwork.WebUI.ViewModels
{
    public class SettingsViewModel
    {
        public UpdatePasswordViewModel UpdatePassword { get; set;}
        public UpdateLoginViewModel UpdateLogin { get; set; }
        public UpdateProfileViewModel UpdateProfile { get; set; }
        public UpdateProfileImageViewModel UpdateProfileImage { get; set; }
    }
}