using ProjectMarketPlace.InternModels;

namespace ProjectMarketPlace.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int? UserEntityId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? Lastupdate { get; set; }

        public virtual User? UserEntity { get; set; }
    }
}
