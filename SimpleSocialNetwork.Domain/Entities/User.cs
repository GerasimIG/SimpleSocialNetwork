using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SimpleSocialNetwork.Domain.EntitiesMetadata;

namespace SimpleSocialNetwork.Domain
{
    [MetadataType(typeof(UserMetadata))]
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
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public System.Guid Password { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public Nullable<int> LocationId { get; set; }
        public byte Gender { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Skype { get; set; }
        public string PhoneNumber { get; set; }
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
