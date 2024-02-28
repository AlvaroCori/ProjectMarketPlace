using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ProjectMarketPlace.Models
{
    [Table("INVENTORY")]
    [DataContract(IsReference = true)]
    public class InventoryEntity
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Column("NAME")]
        public string? Name { get; set; }

        [ForeignKey("InventoryId")]
        public virtual ICollection<ProductEntity>? ProductEntities { get; set; }
    }
}
