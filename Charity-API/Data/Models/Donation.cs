namespace Charity_API.Data.Models
{
    public class Donation
    {
        public int DonationId { get; set; }
        public DateTime DonationDate { get; set; }
        public double DonationAmount { get; set; }
        public double LeftoverAmount { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public User Donator { get; set; }
        public string DonatorId { get; set; }

    }
}
