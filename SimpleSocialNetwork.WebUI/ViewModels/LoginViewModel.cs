using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SimpleSocialNetwork.WebUI.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name="Login (Email)")]
        [RegularExpression(".+@.+", ErrorMessage = "Enter valid email")]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}