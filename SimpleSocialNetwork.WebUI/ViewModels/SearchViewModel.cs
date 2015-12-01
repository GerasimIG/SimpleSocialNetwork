using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleSocialNetwork.Domain;
using System.ComponentModel.DataAnnotations;
using SimpleSocialNetwork.WebUI.UserServiceReference;

namespace SimpleSocialNetwork.WebUI.ViewModels
{
    public class SearchViewModel
    {
        public string UserName {get;set;}
        public string Country {get; set;}
        public string Region {get; set;}
        public string City {get; set;}
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public Nullable<DateTime> BirthDateFrom { get; set; }
        [DataType(DataType.Date)]
        public Nullable<DateTime> BirthDateTo  { get; set; }
        public List<UserDto> SearchResults { get; set; }
    }
}