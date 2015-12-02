using AutoMapper;
using SimpleSocialNetwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleSocialNetwork.BusinessServices.Infrastructure
{
    public class DomainToDtoMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Comment, CommentDto>();
            Mapper.CreateMap<Friend, FriendDto>();
            Mapper.CreateMap<Location, LocationDto>();
            Mapper.CreateMap<Message, MessageDto>();
            Mapper.CreateMap<Post, PostDto>();
            Mapper.CreateMap<User, UserDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.FullLocation,
                opt => opt.MapFrom(o => o.Location.CityName + ", " + o.Location.RegionName + ", " + o.Location.CountryCode)); ;
        }
    }
}