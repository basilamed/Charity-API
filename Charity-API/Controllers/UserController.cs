using Charity_API.Data.DTOs;
using Charity_API.Data.Models;
using Charity_API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Charity_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService userService;
        private readonly UserManager<User> userManager;

        public UserController(UserService userService, UserManager<User> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto user)
        {
            try
            {
                var res = await userService.Register(user);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            try
            {
                var res = await userService.Login(user);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-user-by-id/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            try
            {
                var res = await userService.GetUser(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-user-donations-by-id/{id}")]
        public async Task<IActionResult> GetUserDonationsById(string id)
        {
            try
            {
                var res = await userService.GetUserAndDonations(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var res = await userService.DeleteUser(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-donators")]
        public async Task<IActionResult> GetDonators()
        {
            try
            {
                var res = await userService.GetDonators();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-all-couriers")]
        public async Task<IActionResult> GetCouriers()
        {
            try
            {
                var res = await userService.GetCouriers();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-all-approved")]
        public async Task<IActionResult> GetApproved()
        {
            try
            {
                var res = await userService.GetApproved();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-all-pending")]
        public async Task<IActionResult> GetPending()
        {
            try
            {
                var res = await userService.GetPending();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-all-benefitiaries")]
        public async Task<IActionResult> GetBenefitiaries()
        {
            try
            {
                var res = await userService.GetBenefitiaries();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-all-benefitiaries-with-categories")]
        public async Task<IActionResult> GetBenefitiariesWithCategories()
        {
            try
            {
                var res = await userService.GetAllUsersWithCategories();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("change-password/{id}")]
        public async Task<IActionResult> ChangePassword(string id, [FromBody] ChangePasswordDto user)
        {
            try
            {
                var res = await userService.ChangePassword(id, user);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-user/{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDto user)
        {
            try
            {
                var res = await userService.UpdateUser(id, user);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("approve-user/{id}")]
        public async Task<IActionResult> UpdateUser(string id)
        {
            try
            {
                var res = await userService.ApproveUser(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("change-visibility/{id}")]
        public async Task<IActionResult> ChangeVisibility(string id)
        {
            try
            {
                var res = await userService.ChangeVisibility(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
