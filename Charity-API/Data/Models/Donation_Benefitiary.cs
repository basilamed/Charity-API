namespace Charity_API.Data.Models
{
    public class Donation_Benefitiary
    {
        public int Id { get; set; }
        public int DonationId { get; set; }
        public Donation Donation { get; set; }
        public string BenefitiaryId { get; set; }
        public User Benefitiary { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

    }
}
