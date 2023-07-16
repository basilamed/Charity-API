using Charity_API.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Charity_API.Data.DTOs
{
    public class SendNoteDto
    {
        [Required]
        public int Donation_Benefitiary_Id { get; set; }
        [Required]
        public int NoteId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string DonatorId { get; set; }
    }
}
