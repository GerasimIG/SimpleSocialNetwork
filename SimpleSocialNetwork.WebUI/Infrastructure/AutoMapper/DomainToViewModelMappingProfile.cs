using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.WebUI.ViewModels;
using SimpleSocialNetwork.WebUI.UserServiceReference;
using SimpleSocialNetwork.WebUI.LocationServiceReference;

namespace SimpleSocialNetwork.WebUI.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<UserServiceReference.UserDto, LoginViewModel>();
            Mapper.CreateMap<UserDto, UserViewModel>().ForMember(dest => dest.FullLocation,
                opt => opt.MapFrom(o => o.Location.CityName + ", " + o.Location.RegionName + ", " + o.Location.CountryCode));
            Mapper.CreateMap<UserDto, UpdateLoginViewModel>();
            Mapper.CreateMap<UserDto, EditViewModel>();
            Mapper.CreateMap<UserDto, UpdateProfileViewModel>().ForMember(dest => dest.FullLocation,
                opt => opt.MapFrom(o => o.Location.CityName + ", " + o.Location.RegionName + ", " + o.Location.CountryCode));
            Mapper.CreateMap<UserDto, UpdateProfileImageViewModel>();
        }
    }
}