using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SimpleSocialNetwork.WebUI.ViewModels
{
    public class UpdateLoginViewModel
    {
        [Required]
        [Display(Name="Login (Email)")]
        [RegularExpression(".+@.+", ErrorMessage = "Enter valid email")]
        [MaxLength(60)]
        public string Email { get; set; }
    }
}