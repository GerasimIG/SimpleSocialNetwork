using AutoMapper;
using SimpleSocialNetwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleSocialNetwork.BusinessServices.Infrastructure
{
    public class DtoToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CommentDto, Comment>();
            Mapper.CreateMap<FriendDto, Friend>();
            Mapper.CreateMap<LocationDto, Location>();
            Mapper.CreateMap<MessageDto, Message>();
            Mapper.CreateMap<PostDto, Post>();
            Mapper.CreateMap<UserDto, User>();
        }
    }
}