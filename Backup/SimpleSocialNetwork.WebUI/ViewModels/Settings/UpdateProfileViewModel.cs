using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SimpleSocialNetwork.WebUI.ViewModels
{
    enum GenderTypes : byte
    {
        Unknown = 0,
        Male = 1,
        Female = 2
    }
    public class UpdateProfileViewModel
    {
        [Required]
        [Display(Name="First Name")]
        [MaxLength(60)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(60)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public int LocationId { get; set; }
        [HiddenInput(DisplayValue = false)]        
        public string FullLocation { get; set; }
        [Display(Name="Gender")]        
        public byte Gender { get; set; }
        public IEnumerable<SelectListItem> GendersList { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Birthday { get; set; }
        [MaxLength(45)]
        public string Skype { get; set; }
        [Display(Name="Phone Number")]
        [MaxLength(25)]
        public string PhoneNumber { get; set; }
        
    }
}