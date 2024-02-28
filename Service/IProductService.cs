using ProjectMarketPlace.API.Request;
using ProjectMarketPlace.Common;
using ProjectMarketPlace.Models;

namespace ProjectMarketPlace.Service
{
    public interface IProductService
    {
        Task<BaseResponse<PageData<Product>>> listWithPagination(PageFilter filter);
        Task<BaseResponse<Product>> Register(RegisterProductRequest request);
    }
}
