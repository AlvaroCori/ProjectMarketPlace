using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMarketPlace.Models
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private long Id
        { get; set; }
        [MaxLength(100)]
        [Column("USER_CODE")]
        private string UserCode
        { get; set; }
        [MaxLength(100)]
        [Column("NAME")]
        private string Name
        { get; set; }
        [MaxLength(100)]
        [Column("LAST_NAME")]
        private string LastName
        { get; set; }
        [MaxLength(50)]
        [Column("EMAIL")]
        private string Email
        { get; set; }
        
        [MaxLength(50)]
        [Column("PHONE_NUMBER")]
        private string PhoneNumber
        { get; set; }
        [MaxLength(100)]
        [Column("PASSWORD")]
        private string Password
        { get; set; }
    }
}
