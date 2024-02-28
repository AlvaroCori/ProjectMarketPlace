using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ProjectMarketPlace.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal? Amount { get; set; }

        public string? Currency { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
    }
}
