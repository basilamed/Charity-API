using Microsoft.AspNetCore.Identity;
using System.Data;

namespace Charity_API.Data.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? RoleId { get; set; }
        public Roles Role { get; set; }
        public string? Image { get; set; }
        public bool Approved { get; set; }
        public bool? Status { get; set; }
        public List<User_Category> Categories { get; set; }
        public List<User_Donator_Note> DonatorsNotes { get; set; }
        public List<User_Donator_Note> UsersNotes { get; set; }
        public List<Courier_Donation_Benefitiary> Benefitiaries { get; set; }
        public List<Courier_Donation_Benefitiary> Couriers { get; set; }


        public List<Donation> Donations { get; set; }
        public List<Note> Notes { get; set; }
    }
}
