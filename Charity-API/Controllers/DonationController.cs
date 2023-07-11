using Charity_API.Data.DTOs;
using Charity_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Charity_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : Controller
    {
        private readonly DonationService donationService;
        public DonationController(DonationService donationService)
        {
            this.donationService = donationService;
        }

        [HttpGet("all-donations")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await donationService.GetAllDonations();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("all-donations-by-donator-id/{id}")]
        public async Task<IActionResult> GetAllDonations(string id)
        {
            try
            {
                var list = await donationService.GetDonationsByDonatorId(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("donation-by-id/{id}")]
        public async Task<IActionResult> GetDonation(int id)
        {
            try
            {
                var list = await donationService.GetDonationsById(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add-donation")]
        public async Task<IActionResult> Add([FromBody] DonationDto donation)
        {
            try
            {
                await donationService.AddDonation(donation);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
