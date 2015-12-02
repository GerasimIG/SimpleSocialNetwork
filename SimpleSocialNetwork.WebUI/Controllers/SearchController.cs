using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleSocialNetwork.WebUI.Authentication.Abstract;
using SimpleSocialNetwork.WebUI.ViewModels;
using AutoMapper;
using SimpleSocialNetwork.Domain.BL;
using SimpleSocialNetwork.WebUI.UserServiceReference;
using SimpleSocialNetwork.WebUI.LocationServiceReference;

namespace SimpleSocialNetwork.WebUI.Controllers
{
    [Authorize(Roles = "ApprovedMember,Moderator")] 
    public class SearchController : Controller
    {
         private readonly UserServiceClient _userService;
         private readonly LocationServiceClient _locationService;
        public SearchController() 
        {
            _locationService = new LocationServiceClient();
            _userService = new UserServiceClient();
        }
        public ViewResult Index(SearchViewModel model)
        {
            // Подумати над оптимальнішим варіантом
            List<string> CountriesList = _locationService.GetCountries().OrderBy(x => x).ToList();
            List<string> RegionsList = _locationService.GetRegionsByCountryName(model.Country).OrderBy(x => x).ToList();
            List<string> CitiesList = _locationService.GetCitiesByRegionName(model.Region).OrderBy(x => x).ToList();
            
            CountriesList.Insert(0, "Choose a country");
            RegionsList.Insert(0, "Choose a region");
            CitiesList.Insert(0, "Choose a city");

            ViewBag.Country = new SelectList(CountriesList);
            ViewBag.Region = new SelectList(RegionsList);
            ViewBag.City = new SelectList(CitiesList);

            ViewData["Gender"] = model.Gender;

            model.Country = model.Country == "Choose a country" ? String.Empty : model.Country;
            model.Region = model.Region == "Choose a region" ? String.Empty : model.Region;
            model.City = model.City == "Choose a city" ? String.Empty : model.City;

            byte searchGender = 0;

            switch(model.Gender)
            {
                case "Male": searchGender = 1;
                    break;
                case "Female": searchGender = 2;
                    break;
            }

            if (!String.IsNullOrWhiteSpace(model.UserName) || !String.IsNullOrWhiteSpace(model.Country)
                || !String.IsNullOrWhiteSpace(model.Region) || !String.IsNullOrWhiteSpace(model.City) 
                || searchGender != 0 || model.BirthDateFrom != null || model.BirthDateTo != null)
            {
                model.SearchResults = _userService.GetUsersByParams(model.UserName,model.Country,model.Region
                                        ,model.City,searchGender,model.BirthDateFrom,model.BirthDateTo).ToList();
                return View(model);
            }

            model.SearchResults = _userService.GetRandomUsers(Config.UsersPerPage).ToList();
            return View(model);
        }

        public JsonResult GetRegions(string countryName)
        {
            var regions = _locationService.GetRegionsByCountryName(countryName).ToList();
            regions.Insert(0, "Choose a region");
            return Json(regions, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCities(string regionName)
        {
            var cities = _locationService.GetCitiesByRegionName(regionName).ToList();
            cities.Insert(0, "Choose a city");
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
    }
}
