using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;
using System.Runtime.Serialization;

namespace SimpleSocialNetwork.BusinessServices
{
    [ServiceContract]
    public interface ILocationService : IBaseService<Location, LocationDto>
    {
        [OperationContract]
        List<LocationDto> GetLocationsByCityTerm(string term, int quantity);
        [OperationContract]
        List<string> GetCountries();
        [OperationContract]
        List<string> GetRegionsByCountryName(string countryName);
        [OperationContract]
        List<string> GetCitiesByRegionName(string regionName);
    }

    [DataContract]
    public class LocationDto
    {
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
        
    }
}
