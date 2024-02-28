using Microsoft.AspNetCore.Mvc;
using ProjectMarketPlace.API.Request;
using ProjectMarketPlace.Common;
using ProjectMarketPlace.Models;
using ProjectMarketPlace.Service;

namespace ProjectMarketPlace.Controllers
{

    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("{id}")]
        public async Task<BaseResponse<PageData<Product>>> ListWithPagination([FromQuery] PageFilter filter)
        {
            return await _productService.listWithPagination(filter);
        }
        [HttpPost("register")]
        public async Task<BaseResponse<Product>> Register([FromForm] RegisterProductRequest request)
        {
            return await _productService.Register(request);
        }

    }
}
