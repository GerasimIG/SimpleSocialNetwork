using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.WebUI.ViewModels;
using SimpleSocialNetwork.WebUI.Security.Abstract;
using SimpleSocialNetwork.WebUI.Security.Concrete;

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
            Mapper.CreateMap<User, LoginViewModel>();
            Mapper.CreateMap<User, UserViewModel>().ForMember(dest => dest.FullLocation,
                opt => opt.MapFrom(o => o.Location.CityName + ", " + o.Location.RegionName + ", " + o.Location.CountryCode));
            Mapper.CreateMap<User, UpdateLoginViewModel>();
            Mapper.CreateMap<User, EditViewModel>();
            Mapper.CreateMap<User, UpdateProfileViewModel>().ForMember(dest => dest.FullLocation,
                opt => opt.MapFrom(o => o.Location.CityName + ", " + o.Location.RegionName + ", " + o.Location.CountryCode));
            Mapper.CreateMap<User, UpdateProfileImageViewModel>();
        }
    }
}