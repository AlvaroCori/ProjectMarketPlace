using AutoMapper;
using ProjectMarketPlace.Models;

namespace ProjectMarketPlace.Mappers
{
    public static class ModelMapper
    {
        public static void Configure(ref IMapperConfigurationExpression cfg) 
        {

            //cfg.CreateMap<UserEntity, DTO.User>().ReverseMap();
            
            cfg.CreateMap<UserEntity, User>()
                .ForMember(ue => ue.PhoneNumber, u => u.Ignore())
                .ForMember(ue => ue.Name, u => u.MapFrom(up =>up.Name + " " + up.LastName))
                .ReverseMap()
                .ForMember(ue => ue.Name, u => u.Ignore());
            
            // Products
            cfg.CreateMap<ProductEntity, Product>()
                .ReverseMap();
            /*
            // Revise the fields of this map
            // Inventory
            cfg.CreateMap<InventoryEntity, Inventory>()
                .ReverseMap();
            */
            // Order
            cfg.CreateMap<OrderEntity, Order>()
                .ReverseMap();
            

        }
    }
}
