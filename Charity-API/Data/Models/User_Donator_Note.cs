namespace Charity_API.Data.Models
{
    public class User_Donator_Note
    {
        public int Id { get; set; }
        public int NodeId { get; set; }
        public Note Note { get; set; }
        public string UserId { get; set; }
        public User Benefitiary { get; set; }
        public string DonatorId { get; set; }
        public User Donator { get; set; }
    }
}
