using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocialNetwork.Domain
{
    [DataContract]
    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
