using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Domain.Interfaces;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract;


namespace SimpleSocialNetwork.Infrastructure.Data.Repositories.Concrete
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {

        public IEnumerable<Location> GetLocationsByCityTerm(string term, int quantity)
        {
            var locations = (from l in dbContext.Locations
                             where l.CityName.StartsWith(term)
                             select l).Take(quantity);

            return locations;
        }
        public IEnumerable<string> GetCountries()
        {
            var countries= (from c in dbContext.Locations
                          select c.CountryName).Distinct();
            return countries;
        }

        public IEnumerable<string> GetRegionsByCountryName(string countryName)
        {
            var regions = (from r in dbContext.Locations
                           where r.CountryName == countryName
                           select r.RegionName).Distinct();

            return regions;
        }

        public IEnumerable<string> GetCitiesByRegionName(string regionName)
        {
            var cities = (from r in dbContext.Locations
                           where r.RegionName == regionName
                           select r.CityName).Distinct();
            return cities;
        }
    }
}
