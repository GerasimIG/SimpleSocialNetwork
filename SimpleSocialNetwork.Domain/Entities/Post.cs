using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SimpleSocialNetwork.Domain.EntitiesMetadata;

namespace SimpleSocialNetwork.Domain
{
    [MetadataType(typeof(PostMetadata))]
    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Message { get; set; }
        public System.DateTime DatePosted { get; set; }
        public int AuthorId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual User User { get; set; }
    }
}
