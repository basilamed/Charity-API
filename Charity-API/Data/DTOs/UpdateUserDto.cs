using System.ComponentModel.DataAnnotations;

namespace Charity_API.Data.DTOs
{
    public class UpdateUserDto
    {
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string City { get; set; }
        
        public string Address { get; set; }
        
        public DateTime Birthday { get; set; }

        public string? Image { get; set; }
    }
}
