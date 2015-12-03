using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.WebUI.ViewModels;
using SimpleSocialNetwork.WebUI.UserServiceReference;
using SimpleSocialNetwork.WebUI.FriendServiceReference;
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
            Mapper.CreateMap<UserServiceReference.UserDto, UserViewModel>();
            Mapper.CreateMap<UserServiceReference.UserDto, UpdateLoginViewModel>();
            Mapper.CreateMap<UserServiceReference.UserDto, EditViewModel>();
            Mapper.CreateMap<UserServiceReference.UserDto, UpdateProfileViewModel>();
            Mapper.CreateMap<UserServiceReference.UserDto, UpdateProfileImageViewModel>();
            Mapper.CreateMap<FriendServiceReference.UserDto, UserServiceReference.UserDto>();
        }
    }
}