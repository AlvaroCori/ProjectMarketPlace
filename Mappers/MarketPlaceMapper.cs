using AutoMapper;
namespace ProjectMarketPlace.Mappers
{
    public static class MarketPlaceMapper
    {
        public static readonly Action<IMapperConfigurationExpression> mapperTarget = Config;
        public static void Configure() 
        {
            Mapper.Initialize(mapperTarget);
        } 
        private static void Config(IMapperConfigurationExpression config) 
        {
            ModelMapper.Configure(ref config);
            RequestMapper.Configure(ref config);
        }
    }
}
