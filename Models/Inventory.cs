namespace ProjectMarketPlace.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? Balance { get; set; }

        public DateTime? InDate { get; set; }

        public DateTime? OutDate { get; set; }

        public int? IdProduct { get; set; }

        public virtual Product? IdProductNavigation { get; set; }
    }
}
