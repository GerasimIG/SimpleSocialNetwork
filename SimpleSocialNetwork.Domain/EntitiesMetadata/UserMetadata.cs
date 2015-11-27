using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SimpleSocialNetwork.Domain.EntitiesMetadata
{
    public class UserMetadata
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]    
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Login (Email)")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public System.Guid Password { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public Nullable<int> LocationId { get; set; }
        public byte Gender { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Skype { get; set; }
        public string PhoneNumber { get; set; }
    }
}
