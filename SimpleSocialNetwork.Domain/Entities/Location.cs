using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SimpleSocialNetwork.Domain.EntitiesMetadata;

namespace SimpleSocialNetwork.Domain
{
    [MetadataType(typeof(LocationMetadata))]
    public  class Location
    {
        public Location()
        {
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string RegionName { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
