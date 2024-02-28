
using Microsoft.AspNetCore.Mvc;
using ProjectMarketPlace.API.Request;
using ProjectMarketPlace.API.Response;
using ProjectMarketPlace.Common;
using ProjectMarketPlace.Service;

namespace ProjectMarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("signup")]
        public async Task<BaseResponse<SignUpResponse>> SignUp([FromBody] SignupRequest request)
        {
            return await _authenticationService.SignUp(request);
        }
        [HttpPost("login")]
        public async Task<BaseResponse<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            return await _authenticationService.Login(request);
        }
        /*
         * 
         <summary>
        Autenticacion de servicio
        </summary>
        <param name="request"</param>
        <remarks>
            POST api/Authorization/login
            "userCode":"admin2",
            "password":"123"
        </remarks>
         */

        /// <summary>
        /// Autenticacion de servicio
        /// </summary>
        /// <param name="request"></param>
        /// <remarks>
        ///     POST api/Authentication/login
        ///     {
        ///         "userCode": "admin2",
        ///         "password": "Abc#123"
        ///     }
        /// </remarks>
        /// <returns>token de autenticacion</returns>
    }
}

