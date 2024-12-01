using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Finance.Models
{
    public class ChangePassword
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public required string OldPassword { get; set; }

        [Required]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public required string NewPassword { get; set; }
    }
}
