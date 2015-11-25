using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain.Interfaces;

namespace SimpleSocialNetwork.Domain.Services
{
    public class LocationService : BaseService<Location>, ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
            : base(locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public IEnumerable<Location> GetLocationsByCityTerm(string term, int quantity)
        {
            return _locationRepository.GetLocationsByCityTerm(term, quantity);
        }

        public IEnumerable<string> GetCountries()
        {
           return _locationRepository.GetCountries();
        }

        public IEnumerable<string> GetRegionsByCountryName(string countryName)
        {
            return _locationRepository.GetRegionsByCountryName(countryName);
        }

        public IEnumerable<string> GetCitiesByRegionName(string regionName)
        {
            return _locationRepository.GetCitiesByRegionName(regionName);
        }
    }
}
