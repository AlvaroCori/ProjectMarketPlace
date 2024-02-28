using ProjectMarketPlace.API.Request;
using ProjectMarketPlace.Common;
using ProjectMarketPlace.Models;
using ProjectMarketPlace.Repository.Contract;

namespace ProjectMarketPlace.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<BaseResponse<PageData<Product>>> listWithPagination(PageFilter filter)
        {
            var page = await _productRepository.ListWithPagination(filter);
            return new BaseResponse<PageData<Product>>(page);
        }

        public async Task<BaseResponse<Product>> Register(RegisterProductRequest request)
        {
            var productEntity = AutoMapper.Mapper.Map<ProductEntity>(request);
            var product = await _productRepository.Create(productEntity);
            return new BaseResponse<Product>(product);
        }
    }
}
