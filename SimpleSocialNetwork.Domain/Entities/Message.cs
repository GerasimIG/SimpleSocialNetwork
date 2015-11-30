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
    [MetadataType(typeof(MessageMetadata))]
    [DataContract]
    public  class Message
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int FromUserId { get; set; }
        [DataMember]
        public int ToUserId { get; set; }
        [DataMember]
        public string MsgText { get; set; }
        [DataMember]
        public System.DateTime DateSent { get; set; }

        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
