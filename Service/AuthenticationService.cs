using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using NETCore.Encrypt;
using ProjectMarketPlace.API.Request;
using ProjectMarketPlace.API.Response;
using ProjectMarketPlace.Common;
using ProjectMarketPlace.Models;
using ProjectMarketPlace.Repository.Implementation;
using System.IdentityModel.Tokens.Jwt;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;


namespace ProjectMarketPlace.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        public const string PASSWORD_KEY = "123";
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration configuration;
        public AuthenticationService(IConfiguration configuration, IUserRepository userRepository)
        {
            this.configuration = configuration;
            this._userRepository = userRepository;
        }
        public async Task<BaseResponse<LoginResponse>> Login(LoginRequest request)
        {
            var user = await _userRepository.findByUserCode(request.UserCode!);
            //use this if when you use password with HMACSHA256 encrypter
            //if (user.Password != EncryptProvider.HMACSHA256(request.Password, AuthenticationService.PASSWORD_KEY))
            user.Password = user.Password.Replace(" ", "");

            if (user.Password != request.Password)
            {
                throw new CustomException("Contraseña invalida");
            }
            var token = BuildToken("admin");
            var result = new LoginResponse()
            {
                UserName = user.Name,
                Token = token
            };
            return new BaseResponse<LoginResponse>(result);
        }
        public async Task<BaseResponse<SignUpResponse>> SignUp(SignupRequest request)
        {
            //var cipher = EncryptProvider.HMACSHA256(request.Password, PASSWORD_KEY);
            var userEntity = AutoMapper.Mapper.Map<UserEntity>(request);
            var user = await _userRepository.Create(userEntity);
            var response = new SignUpResponse
            {
                UserName = user.Name
            };
            return new BaseResponse<SignUpResponse>(response);
        }
        public string BuildToken(string userCode, double expiration = 1)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userCode),
                //new Claim(ClaimTypes.Role, "admin"),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            };
            var le1 = configuration["Jwt:CustomAuthentication:SecretKey"]!;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:CustomAuthentication:SecretKey"]!));
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abcd"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var expirationToken = DateTime.Now.AddMinutes(expiration);
            var TokenDescriptor = new JwtSecurityToken(
                //issuer: configuration?["Jwt.CustomAuthentication.ValidateIssuer"],
                //audience: configuration?["Jwt.CustomAuthentication.ValidAudience"],
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                claims: claims,
                expires: expirationToken,
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(TokenDescriptor);
        }
        
    }
}


