using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;

namespace SimpleSocialNetwork.Domain.Interfaces
{
    public interface ILocationService : IBaseService<Location>
    {
        IEnumerable<Location> GetLocationsByCityTerm(string term, int quantity);
        IEnumerable<string> GetCountries();
        IEnumerable<string> GetRegionsByCountryName(string countryName);
        IEnumerable<string> GetCitiesByRegionName(string regionName);
    }
}
