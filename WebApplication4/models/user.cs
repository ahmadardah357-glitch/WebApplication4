using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication4.models;

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

    [Table("signupp")]
    public class signupp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "الاسم مطلوب")]
        [StringLength(100, ErrorMessage = "الاسم لا يمكن أن يتجاوز 100 حرف")]
        public string Name { get; set; }

        [Required(ErrorMessage = "العمر مطلوب")]
        [Range(1, 120, ErrorMessage = "العمر يجب أن يكون بين 1 و 120")]
        public int Age { get; set; }

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
        [EmailAddress(ErrorMessage = "صيغة البريد الإلكتروني غير صحيحة")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "كلمة المرور مطلوبة")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "كلمة المرور يجب أن تكون 6 أحرف على الأقل")]
        public string Password { get; set; }

        [Required(ErrorMessage = "نوع المستخدم مطلوب")]
        [StringLength(20)]
        public string UserType { get; set; }

        public DateTime Created_at { get; set; }

        public DateTime Update_at { get; set; }

        [StringLength(20)]
        public string NationalId { get; set; }

        [StringLength(100)]
        public string Cancer_type { get; set; }
    }
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

