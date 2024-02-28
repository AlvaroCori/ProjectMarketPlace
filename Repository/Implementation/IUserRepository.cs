using ProjectMarketPlace.Models;
namespace ProjectMarketPlace.Repository.Implementation
{
    public interface IUserRepository
    {
        public Task<User> FindById(int id);
        Task<User> findByUserCode(string userCode);
        public Task<User> Create(UserEntity userEntity);
        public Task<List<User>> List();
        public Task<User> Update(int id, UserEntity entity);
        public Task<User> Delete(int id);
    }
}
