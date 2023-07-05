namespace Charity_API.Data.Models
{
    public class Courier_Donation_Benefitiary
    {
        public int Id { get; set; }
        public int DonationId { get; set; }
        public Donation Donation { get; set; }
        public string CourierId { get; set; }
        public User Courier { get; set; }
        public string BenefitiaryId { get; set; }
        public User Benefitiary { get; set; }

    }
}
