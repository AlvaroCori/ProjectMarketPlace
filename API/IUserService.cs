using ProjectMarketPlace.Common;
using ProjectMarketPlace.Models;

namespace ProjectMarketPlace.API
{
    public interface IUserService
    {
        Task<BaseResponse<User>> FindById(int id);
        Task<BaseResponse<User>> Create(UserRequest user);
        Task<BaseResponse<User>> Update(int id, UserRequest user);
        Task<BaseResponse<User>> Delete(int id);
    }
}


