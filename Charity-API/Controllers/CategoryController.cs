using Charity_API.Data.DTOs;
using Charity_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Charity_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly CategoryService categoryService;
        public 
            CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("all-categories")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await categoryService.GetAllCategories();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("all-categories-with-users")]
        public async Task<IActionResult> GetAllWithUsers()
        {
            try
            {
                var list = await categoryService.GetAllCategoriesWithUsers();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-category-by-user-id/{id}")]
        public async Task<IActionResult> GetByUserId(string id)
        {
            try
            {
                var list = await categoryService.GetCategoriesByUserId(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-pending-category-by-user-id/{id}")]
        public async Task<IActionResult> GetCAtegoryByUserId(string id)
        {
            try
            {
                var list = await categoryService.GetNCategoriesByUserId(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-category")]
        public async Task<IActionResult> Add([FromBody] CategoryDto category)
        {
            try
            {
                await categoryService.AddCategory(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUserCategory([FromBody] CategoryUserDto dto)
        {
            try
            {
                var cd = await categoryService.CreateUser_Category(dto);
                return Ok(cd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("remove-user-category")]
        public async Task<IActionResult> DeleteUserCategory(CategoryUserDto dto)
        {
            try
            {
                var res = await categoryService.DeleteUser_Category(dto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
