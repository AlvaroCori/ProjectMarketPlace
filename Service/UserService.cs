using Azure.Core;
using ProjectMarketPlace.API;
using ProjectMarketPlace.Common;
using ProjectMarketPlace.Models;
using ProjectMarketPlace.Repository.Implementation;
using System.Threading.Tasks;


namespace ProjectMarketPlace.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<BaseResponse<User>> Create(UserRequest request)
        {
            var userEntity = AutoMapper.Mapper.Map<UserEntity>(request);
            var user = await _userRepository.Create(userEntity);
            return new BaseResponse<User>(user);
        }

        public async Task<BaseResponse<User>> Delete(int id)
        {
            var user = await _userRepository.Delete(id);

            return new BaseResponse<User>(user);
        }

        public async Task<BaseResponse<User>> FindById(int id)
        {
            var user = await _userRepository.FindById(id);

            return new BaseResponse<User>(user);
        }

        public async Task<BaseResponse<User>> Update(int id, UserRequest request)
        {
            var userEntity = AutoMapper.Mapper.Map<UserEntity>(request);
            var user = await _userRepository.Update(id, userEntity);

            return new BaseResponse<User>(user);
        }
    }
}

