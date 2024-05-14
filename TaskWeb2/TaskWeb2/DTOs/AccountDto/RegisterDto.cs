using System.ComponentModel.DataAnnotations;

namespace TaskWeb2.DTOs.AccountDto
{
    public class RegisterDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Name {  get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Surname {  get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [DataType(DataType.Password),Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
