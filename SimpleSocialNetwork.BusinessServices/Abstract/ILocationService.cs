using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;

namespace SimpleSocialNetwork.BusinessServices
{
    [ServiceContract]
    public interface ILocationService : IBaseService<Location>
    {
        [OperationContract]
        IEnumerable<Location> GetLocationsByCityTerm(string term, int quantity);
        [OperationContract]
        IEnumerable<string> GetCountries();
        [OperationContract]
        IEnumerable<string> GetRegionsByCountryName(string countryName);
        [OperationContract]
        IEnumerable<string> GetCitiesByRegionName(string regionName);
    }
}
