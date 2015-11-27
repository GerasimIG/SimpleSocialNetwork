using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SimpleSocialNetwork.Domain.EntitiesMetadata;

namespace SimpleSocialNetwork.Domain
{
    [MetadataType(typeof(FriendMetadata))]
    public class Friend
    {
        public int Id { get; set; }
        public int FirstUserId { get; set; }
        public int SecondUserId { get; set; }

        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
