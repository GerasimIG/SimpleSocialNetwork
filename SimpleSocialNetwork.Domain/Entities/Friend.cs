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
    [MetadataType(typeof(FriendMetadata))]
    [DataContract]
    public class Friend
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int FirstUserId { get; set; }
        [DataMember]
        public int SecondUserId { get; set; }

        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
