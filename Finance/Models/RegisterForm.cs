using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Finance.Models
{
    public class RegisterForm
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public required string Email {  get; set; }

        [Required]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public required string ConfirmPassword { get; set; }
    }
}
