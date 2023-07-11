using Charity_API.Data.Models;

namespace Charity_API.Data.DTOs
{
    public class DonationDto
    {
        public DateTime DonationDate { get; set; }
        public double DonationAmount { get; set; }
        public int CategoryId { get; set; }
        public string DonatorId { get; set; }
    }
}
