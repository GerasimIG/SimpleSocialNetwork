using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using SimpleSocialNetwork.Domain.EntitiesMetadata;

namespace SimpleSocialNetwork.Domain
{
    [MetadataType(typeof(CommentMetadata))]
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public System.DateTime DatePosted { get; set; }
        public int AuthorId { get; set; }
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
