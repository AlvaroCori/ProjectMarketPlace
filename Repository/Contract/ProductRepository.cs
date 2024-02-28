using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectMarketPlace.Common;
using ProjectMarketPlace.Models;
using ProjectMarketPlace.Repository.Implementation;

namespace ProjectMarketPlace.Repository.Contract
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketPlaceDBContext _dbContext;
        ILogger<ProductRepository> _logger;
        public ProductRepository(MarketPlaceDBContext dbContext, ILogger<ProductRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<Product> Create(ProductEntity productEntity)
        {
            // Traer referencia de product DB Set
            var dbSet = _dbContext.Set<ProductEntity>();
            await dbSet.AddAsync(productEntity);
            await _dbContext.SaveChangesAsync();

            // Retornamos product
            return AutoMapper.Mapper.Map<Product>(productEntity);
        }

        public async Task<Product> Delete(int id)
        {

            var productEntity = await _dbContext.Set<ProductEntity>().FindAsync(id);
            if (productEntity != null)
            {
                throw new Exception("Not found");
            }
            //Remover Entidad
            var dbSet = _dbContext.Set<ProductEntity>();
            //await dbSet.Remove(userEntity);
            return AutoMapper.Mapper.Map<Product>(productEntity);
        }

        public async Task<Product> FindById(int id)
        {
            try
            {
                var productEntity = await _dbContext.Set<ProductEntity>().FindAsync(id);
                if (productEntity != null)
                {
                    _logger.LogInformation("Not found");
                    throw new Exception("Not found");
                }
                _logger.LogInformation($"ProductID Found: {id}");
                return AutoMapper.Mapper.Map<Product>(productEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> findByProductCode(string productCode)
        {
            var productEntity = await _dbContext.Set<ProductEntity>()
                .Where(x => x.Id == x.Id)
                .FirstOrDefaultAsync();
            _logger.LogInformation($"ProductID Found: {productEntity.Id}");
            return AutoMapper.Mapper.Map<Product>(productEntity);
        }

        public async Task<List<Product>> List()
        {
            var productEntities = await _dbContext.Set<ProductEntity>().ToListAsync();
            return AutoMapper.Mapper.Map<List<Product>>(productEntities);
        }

        public async Task<PageData<Product>> ListWithPagination(PageFilter filter)
        {
            var totalRecords = await _dbContext.Set<ProductEntity>().CountAsync();
            var pageData = await _dbContext.Set<ProductEntity>().Skip((filter.PageNumber - 1) * filter.PageSize).Take((filter.PageSize)).ToListAsync();
            return PaginationHelper.CreatePagination(AutoMapper.Mapper.Map<List<Product>>(pageData), filter, totalRecords);
        }

        public async Task<Product> Update(int id, ProductEntity entity)
        {
            var entityN = await _dbContext.Set<ProductEntity>().FindAsync(id);
            if (entity == null)
            {
                throw new CustomException("Not Found");
            }
            entityN.Id = entity.Id;
            _dbContext.Entry(entity).CurrentValues.SetValues(entityN);
            await _dbContext.SaveChangesAsync();

            return AutoMapper.Mapper.Map<Product>(entityN);
        }
    }
}
