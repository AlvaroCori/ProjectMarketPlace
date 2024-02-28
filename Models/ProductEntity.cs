using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ProjectMarketPlace.Models
{
    [Table("PRODUCT")]
    [DataContract(IsReference = true)]
    public class ProductEntity
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100)]
        [Column("NAME")]
        public string? Name { get; set; }
        [Column("AMOUNT")]
        public decimal? Amount { get; set; }
        [MaxLength(100)]
        [Column("CURRENCY")]
        public string? Currency { get; set; }
        [Column("DESCRIPTION", TypeName = "TEXT")]
        public string? Description { get; set; }

        [Column("LAST_UPDATE", TypeName = "DATETIME")]
        public DateTime? LastUpdate { get; set; }

        [Column("INVENTORY_ID")]
        public int? InventoryId { get; set; }
        [MaxLength(50)]
        [Column("CATEGORY")]
        public string Category { get; set; }
        [Column("PROPIERTY_ID")]
        public int? PropiertyId { get; set; }
        [Column("POINTS")]
        public int? Points { get; set; }
        [Column("IMAGE", TypeName = "VARBINARY(MAX)")]
        public byte[]? Image { get; set; }
    }
}
