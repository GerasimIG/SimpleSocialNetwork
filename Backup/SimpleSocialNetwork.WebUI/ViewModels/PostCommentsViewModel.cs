using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleSocialNetwork.Domain;

namespace SimpleSocialNetwork.WebUI.ViewModels
{
    public class PostCommentsViewModel
    {
        public int PostId { get; set; }
        public List<Comment> PostComments { get; set; }
    }
}