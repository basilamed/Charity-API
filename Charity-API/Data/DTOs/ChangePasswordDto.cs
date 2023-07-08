using System.ComponentModel.DataAnnotations;

namespace Charity_API.Data.DTOs
{
    public class ChangePasswordDto
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required, Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}
