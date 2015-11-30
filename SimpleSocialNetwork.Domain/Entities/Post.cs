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
    [MetadataType(typeof(PostMetadata))]
    [DataContract]
    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public System.DateTime DatePosted { get; set; }
        [DataMember]
        public int AuthorId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual User User { get; set; }
    }
}
