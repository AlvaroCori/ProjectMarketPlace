using System.ComponentModel.DataAnnotations;

namespace ProjectMarketPlace.API.Request
{
    public class LoginRequest
    {
        //[Required]
        //[StringLength(5)]
        //[RegularExpression(@"^[a-zA-Z0-9''-'\s]{1,40}$")]
        public string? UserCode { get; set; }
        //[Required]
        //[StringLength(5)]
        public string? Password { get; set; }
    }
}
