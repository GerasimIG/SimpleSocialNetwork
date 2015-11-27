using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SimpleSocialNetwork.WebUI.ViewModels
{
    public class UpdateProfileImageViewModel
    {
        public byte[] ImageData { get; set; }
        [MaxLength(40)]
        public string ImageMimeType { get; set; }   
    }
}