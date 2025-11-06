using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.models
{
    [Table("signin")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Emailaddress { get; set; }  
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
    [Table("password_resets", Schema = "dbo")]
    public class PasswordReset
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [Column("User_Id")]
        public int UserId { get; set; }
        [Required]
        [MaxLength(6)]
        [Column("Reset_code")]
        public string Reset_code { get; set; }
        [Required]
        [Column("Expires_at")]
        public DateTime Expires_at { get; set; }
        [Required]
        [Column("Used")]
        public bool Used { get; set; }
        [Required]
        [Column("Created_at")]
        public DateTime Created_at { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

    }
}
