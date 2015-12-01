using AutoMapper;
using SimpleSocialNetwork.BusinessServices.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleSocialNetwork.BusinessServices.AutoMapper
{ 
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToDtoMappingProfile>();
                x.AddProfile<DtoToDomainMappingProfile>();
            }
            );
        }
    }
}