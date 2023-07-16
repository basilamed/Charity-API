using System.ComponentModel.DataAnnotations;

namespace Charity_API.Data.DTOs
{
    public class DonationBenefitiaryDto
    {
        [Required]
        public int DonationId { get; set; }
        [Required]
        public string BenefitiaryId { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}
