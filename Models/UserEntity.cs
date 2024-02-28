using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ProjectMarketPlace.Models
{
    [Table("USERP")]
    [DataContract(IsReference = true)]
    public class UserEntity
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        { get; set; }
        [MaxLength(100)]
        [Column("USER_CODE")]
        public string? UserCode
        { get; set; }
        [MaxLength(100)]
        [Column("NAME")]
        public string? Name
        { get; set; }
        [MaxLength(100)]
        [Column("LAST_NAME")]
        public string? LastName
        { get; set; }
        [MaxLength(50)]
        [Column("EMAIL")]
        public string? Email
        { get; set; }
        
        [MaxLength(50)]
        [Column("PHONE_NUMBER")]
        public string? PhoneNumber
        { get; set; }
        //[MaxLength(1000)]
        [Column("PASSWORD")]
        public string? Password
        { get; set; }
    }
}
