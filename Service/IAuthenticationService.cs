using ProjectMarketPlace.API.Request;
using ProjectMarketPlace.API.Response;
using ProjectMarketPlace.Common;

namespace ProjectMarketPlace.Service
{
    public interface IAuthenticationService
    {
        Task<BaseResponse<LoginResponse>> Login(LoginRequest loginRequest);
        Task<BaseResponse<SignUpResponse>> SignUp(SignupRequest request);
    }
}