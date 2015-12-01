using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SimpleSocialNetwork.WebUI.ViewModels;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.WebUI.Security.Abstract;
using SimpleSocialNetwork.WebUI.Security.Concrete;
using SimpleSocialNetwork.WebUI.FriendServiceReference;

namespace SimpleSocialNetwork.WebUI.AutoMapper
{
    public class ViewModelToDomainMappingProfile :Profile
    {
        private readonly IHash _hash = new MD5Hash();
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<SignupViewModel, UserDto>().ForMember(dest => dest.Password, 
                opt => opt.MapFrom(o => this._hash.HashString(o.Password)));
            Mapper.CreateMap<UpdateProfileViewModel, UserDto>();
            Mapper.CreateMap<EditViewModel, UserDto>();
        }
    }
}