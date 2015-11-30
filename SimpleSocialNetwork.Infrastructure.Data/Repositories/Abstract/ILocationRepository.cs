using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;

namespace SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract
{
    public interface ILocationRepository : IBaseRepository<Location>
    {
        IEnumerable<Location> GetLocationsByCityTerm(string term, int quantity);
        IEnumerable<string> GetCountries();
        IEnumerable<string> GetRegionsByCountryName(string countryName);
        IEnumerable<string> GetCitiesByRegionName(string regionName);
    }
}
