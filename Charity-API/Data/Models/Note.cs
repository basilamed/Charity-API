namespace Charity_API.Data.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Review { get; set; }
        public DateTime DateTime { get; set; }
        public List<User_Donator_Note> Notes { get; set; }
    }
}
