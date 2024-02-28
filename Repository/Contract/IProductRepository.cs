using ProjectMarketPlace.Common;
using ProjectMarketPlace.Models;

namespace ProjectMarketPlace.Repository.Contract
{
    public interface IProductRepository
    {
        public Task<Product> FindById(int id);
        Task<Product> findByProductCode(string productCode);
        public Task<Product> Create(ProductEntity productEntity);
        public Task<List<Product>> List();
        public Task<PageData<Product>> ListWithPagination(PageFilter filter);
        public Task<Product> Update(int id, ProductEntity entity);
        public Task<Product> Delete(int id);
    }
}
