using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.WebUI.CommentServiceReference;

namespace SimpleSocialNetwork.WebUI.ViewModels
{
    public class PostCommentsViewModel
    {
        public int PostId { get; set; }
        public List<CommentDto> PostComments { get; set; }
    }
}