using System.ComponentModel.DataAnnotations;

namespace Charity_API.Data.DTOs
{
    public class NoteDto
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public int Review { get; set; }

    }
}
