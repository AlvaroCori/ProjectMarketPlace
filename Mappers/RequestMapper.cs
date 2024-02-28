using AutoMapper;
using NETCore.Encrypt;
using ProjectMarketPlace.API;
using ProjectMarketPlace.API.Request;
using ProjectMarketPlace.Models;
using ProjectMarketPlace.Service;
using System.Security.Cryptography.Xml;
using Azure.Core;
using ProjectMarketPlace.Common;


namespace ProjectMarketPlace.Mappers
{
    public static class RequestMapper
    {
        public static void Configure(ref IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UserRequest, UserEntity>()
                .ForMember(p => p.Id, opt => opt.Ignore());
            cfg.CreateMap<SignupRequest, UserEntity>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.Password, opt => opt.MapFrom(src => EncryptProvider.HMACSHA256(src.Password, AuthenticationService.PASSWORD_KEY)));

            //.ForMember(p=> p.Password, opt => opt.MapFrom(src => EncryptProvider)  EncryptProvider.HMACSHA256(request.Password, PASSWORD_KEY));
            // UserRequest

            cfg.CreateMap<RegisterProductRequest, ProductEntity>()
                .ForMember(p => p.Id, opt => opt.Ignore()).
                ForMember(p => p.LastUpdate, opt => opt.MapFrom(src => DateTime.Now)).
                ForMember(p => p.Image, opt => opt.MapFrom(src => Helper.ToByteArray(src.Image))).
                ForMember(p => p.InventoryId, opt => opt.MapFrom(src => 1));
        }
    }
}
