using System.ComponentModel.DataAnnotations;

namespace Charity_API.Data.DTOs
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
