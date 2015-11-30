using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Concrete;

namespace SimpleSocialNetwork.BusinessServices.Concrete
{
    public class LocationService : BaseService<Location>, ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        public LocationService()
        {
            _locationRepository = new LocationRepository();
            _repository = _locationRepository;
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
