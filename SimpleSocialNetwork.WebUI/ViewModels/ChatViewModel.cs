using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SimpleSocialNetwork.WebUI.ViewModels
{
    public class ChatViewModel
    {
        public int ChatWithUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] ImageData { get; set; }
        public string LastMessage { get; set; }
        public string LastMessageAuthorName { get; set; }
        public DateTime DateSent { get; set; }
    }
}