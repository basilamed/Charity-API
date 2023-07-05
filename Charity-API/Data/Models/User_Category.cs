namespace Charity_API.Data.Models
{
    public class User_Category
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
