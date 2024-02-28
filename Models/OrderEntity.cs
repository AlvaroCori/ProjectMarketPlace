using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ProjectMarketPlace.Models
{
    [Table("ORDEN")]
    [DataContract(IsReference = true)]
    public class OrderEntity
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("PRODUCT_ID")]
        public virtual ICollection<ProductEntity>? ProductEntities { get; set; }
    }
}
