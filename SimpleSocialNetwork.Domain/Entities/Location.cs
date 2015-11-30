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
    [MetadataType(typeof(LocationMetadata))]
    [DataContract]
    public  class Location
    {
        public Location()
        {
            this.Users = new HashSet<User>();
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CountryCode { get; set; }
        [DataMember]
        public string CountryName { get; set; }
        [DataMember]
        public string RegionName { get; set; }
        [DataMember]
        public string CityName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
