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
}
