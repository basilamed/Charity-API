namespace Charity_API.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User_Category> Users { get; set; }
    }
}
