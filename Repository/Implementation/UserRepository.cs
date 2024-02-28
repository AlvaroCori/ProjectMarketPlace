using Microsoft.EntityFrameworkCore;
using ProjectMarketPlace.Common;
using ProjectMarketPlace.Models;
using ProjectMarketPlace.Repository.Implementation;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;


namespace ProjectMarketPlace.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly MarketPlaceDBContext _dbContext;
        ILogger<UserRepository> _logger;
        public UserRepository(MarketPlaceDBContext dbContext, ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<User> Create(UserEntity userEntity)
        {
            // Traer referencia de User DB Set
            var dbSet = _dbContext.Set<UserEntity>();
            await dbSet.AddAsync(userEntity);
            await _dbContext.SaveChangesAsync();

            // Retornamos User
            return AutoMapper.Mapper.Map<User>(userEntity);
        }

        public async Task<User> Delete(int id)
        {
            //Buscar UserEntity
            var userEntity = await _dbContext.Set<UserEntity>().FindAsync(id);
            if (userEntity != null) 
            {
                throw new Exception("Not found");
            }
            //Remover Entidad
            var dbSet = _dbContext.Set<UserEntity>();
            //await dbSet.Remove(userEntity);
            return AutoMapper.Mapper.Map<User>(userEntity);
        }

        public async Task<User> FindById(int id)
        {
            try
            {
                var userEntity = await _dbContext.Set<UserEntity>().FindAsync(id);
                if (userEntity != null)
                {
                    _logger.LogInformation("Not found");
                    throw new Exception("Not found");
                }
                _logger.LogInformation($"UserID Found: {userEntity.Id}");
                return AutoMapper.Mapper.Map<User>(userEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<User> findByUserCode(string userCode)
        {
            var userEntity = await _dbContext.Set<UserEntity>()
                .Where(x => x.UserCode == userCode)
                .FirstOrDefaultAsync();
            if (userEntity == null)
            {
                _logger.LogInformation("Not found");
                throw new CustomException("User not Found");
            }

            _logger.LogInformation($"UserID Found: {userEntity.Id}");
            return AutoMapper.Mapper.Map<User>(userEntity);

        }
        public async Task<List<User>> List()
        {
            List <UserEntity> userEntities = await _dbContext.Set<UserEntity>().ToListAsync();
            return AutoMapper.Mapper.Map<List<User>>(userEntities);
           
        }
        public async Task<List<User>> list()
        {
            var userEntities = await _dbContext.Set<UserEntity>().ToListAsync();
            return AutoMapper.Mapper.Map<List<User>>(userEntities);
        }
        public async Task<User> Update(int id, UserEntity entity)
        {
            var userEntity = await _dbContext.Set<UserEntity>().FindAsync(id);
            if (userEntity == null)
            {
                throw new CustomException("Not Found");
            }
            entity.Id = userEntity.Id;
            _dbContext.Entry(userEntity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
            return AutoMapper.Mapper.Map<User>(userEntity);
        }
    }
}



