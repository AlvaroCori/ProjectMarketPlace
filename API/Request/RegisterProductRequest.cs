using ProjectMarketPlace.Models;

namespace ProjectMarketPlace.API.Request
{
    public class RegisterProductRequest
    {
        public string? Name { get; set; }
        public decimal? Amount { get; set; }
        public string? Currency { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public int? Points { get; set; }
        public IFormFile? Image { get; set; }
    }
}
