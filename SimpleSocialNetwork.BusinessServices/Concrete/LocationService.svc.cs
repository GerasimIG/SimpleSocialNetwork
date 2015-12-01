using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Concrete;
using AutoMapper;

namespace SimpleSocialNetwork.BusinessServices.Concrete
{
    public class LocationService : BaseService<Location, LocationDto>, ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        public LocationService()
        {
            _locationRepository = new LocationRepository();
            _repository = _locationRepository;
        }

        public List<LocationDto> GetLocationsByCityTerm(string term, int quantity)
        {
            var result = _locationRepository.GetLocationsByCityTerm(term, quantity);

            List<LocationDto> list = null;

            if (result != null)
            {
                list = new List<LocationDto>();
                foreach (var el in result)
                {
                    var locationDto = Mapper.Map<LocationDto>(el);
                    list.Add(locationDto);
                }
            }

            return list;
        }
        public List<string> GetCountries()
        {
            return _locationRepository.GetCountries().ToList();
        }

        public List<string> GetRegionsByCountryName(string countryName)
        {
            return _locationRepository.GetRegionsByCountryName(countryName).ToList();
        }

        public List<string> GetCitiesByRegionName(string regionName)
        {
            return _locationRepository.GetCitiesByRegionName(regionName).ToList();
        }
    }
}
