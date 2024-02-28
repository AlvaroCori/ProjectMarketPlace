using Microsoft.AspNetCore.Mvc;
using ProjectMarketPlace.API;
using ProjectMarketPlace.Common;
using ProjectMarketPlace.Middlewares;
using Azure.Core;
using System.Threading.Tasks;
using ProjectMarketPlace.Models;






// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectMarketPlace.Controllers
{

    //[CustomAuthorization]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new List<string>();
        }

        // GET api/<UserController>/5
        [CustomAuthentication]
        [HttpGet("{id}")]
        public async Task<BaseResponse<User>> Get(int id)
        {
            return await _userService.FindById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<BaseResponse<User>> Create([FromBody] UserRequest request)
        {
            return await _userService.Create(request);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<BaseResponse<User>> Put(int id, [FromBody] UserRequest request)
        {
            return await _userService.Update(id, request);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse<User>> Delete(int id)
        {
            return await _userService.Delete(id);
        }
    }
}



