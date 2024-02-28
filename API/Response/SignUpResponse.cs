using ProjectMarketPlace.Common;

namespace ProjectMarketPlace.API.Response
{
    public class SignUpResponse
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        //Task<BaseResponse<LoginResponse>> LoginResponseTask { get; set; }

    }
}
