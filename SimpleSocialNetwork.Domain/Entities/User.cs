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
    [MetadataType(typeof(UserMetadata))]
    [DataContract]
    public class User
    {
        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.Friends = new HashSet<Friend>();
            this.Friends1 = new HashSet<Friend>();
            this.Messages = new HashSet<Message>();
            this.Messages1 = new HashSet<Message>();
            this.Posts = new HashSet<Post>();
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public System.Guid Password { get; set; }
        [DataMember]
        public byte[] ImageData { get; set; }
        [DataMember]
        public string ImageMimeType { get; set; }
        [DataMember]
        public Nullable<int> LocationId { get; set; }
        [DataMember]
        public byte Gender { get; set; }
        [DataMember]
        public Nullable<System.DateTime> Birthday { get; set; }
        [DataMember]
        public string Skype { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public int RoleId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Friend> Friends { get; set; }
        public virtual ICollection<Friend> Friends1 { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Message> Messages1 { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual Role Role { get; set; }
    }
}
