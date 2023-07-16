using Charity_API.Data.DTOs;
using Charity_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Charity_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : Controller
    {

        private readonly NoteService noteService;
        public
            NoteController(NoteService noteService)
        {
            this.noteService = noteService;
        }
        [HttpGet("all-notes-by-user-id/{id}")]
        public async Task<IActionResult> GetAllByUserId( string id)
        {
            try
            {
                var list = await noteService.GetNotesByUserId(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("all-notes-by-donator-id/{id}")]
        public async Task<IActionResult> GetAllByDonatorId(string id)
        {
            try
            {
                var list = await noteService.GetNotesByDonatorId(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("all-notes-by-donation-benefitiary-id/{id}")]
        public async Task<IActionResult> GetNotesByDonationBenefitiaryId(int id)
        {
            try
            {
                var list = await noteService.GetNotesByDonationBenefitiaryId(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add-user-donator-note")]
        public async Task<IActionResult> AddUserCategory([FromBody] SendNoteDto dto)
        {
            try
            {
                var cd = await noteService.CreateUser_Donator_Note(dto);
                return Ok(cd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add-note")]
        public async Task<IActionResult> AddNote([FromBody] NoteDto dto)
        {
            try
            {
                var cd = await noteService.AddNote(dto);
                return Ok(cd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("see-note/{id}")]
        public async Task<IActionResult> SeeNote(int id)
        {
            try
            {
                var cd = await noteService.ChangeVisibility(id);
                return Ok(cd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
