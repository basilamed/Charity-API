using System.ComponentModel.DataAnnotations;

namespace Charity_API.Data.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public string Password { get; set; }
        public bool? Status { get; set; }
    }
}
