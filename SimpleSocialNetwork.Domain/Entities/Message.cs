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
    public  class Message
    {
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public string MsgText { get; set; }
        public System.DateTime DateSent { get; set; }

        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
