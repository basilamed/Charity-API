using Charity_API.Data.Models;
using Charity_API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Charity_API.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Charity_API.Services
{
    public class CategoryService
    {
        private readonly AppDbContext context;

        public CategoryService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var list = await context.Category.ToListAsync();
            return list;
        }

        public async Task<List<Category>> GetAllCategoriesWithUsers()
        {
            var list = await context.Category.Include(c => c.Users).ToListAsync();
            return list;
        }
        public async Task<int> GetAllCategoriesWithCountUsers(int id)
        {
            var list = await context.Category.Where(c => c.Id == id).Include(c => c.Users).ToListAsync();
            var userCount = list.SelectMany(c => c.Users).Count();
            return (userCount);
        }
        public async Task AddCategory(CategoryDto category)
        {
            var cE = await context.Category.FirstOrDefaultAsync(c => c.Name == category.Name);
            if (cE != null)
            {
                throw new Exception("Category already exists");
            }

            var c = new Category
            {
                Name = category.Name
            };
            context.Category.Add(c);

            await context.SaveChangesAsync();
        }

        public async Task<User_Category> CreateUser_Category(CategoryUserDto categoryUserDto)
        {
            var user = await context.User_Category.FirstOrDefaultAsync(c => c.Id == categoryUserDto.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var category = await context.Category.FirstOrDefaultAsync(d => d.Id == categoryUserDto.CategoryId);
            if (category == null)
            {
                throw new Exception("Category not found");
            }

            var existingUserCategory = await context.User_Categories
                .FirstOrDefaultAsync(uc => uc.UserId == categoryUserDto.UserId && uc.CategoryId == categoryUserDto.CategoryId);
            if (existingUserCategory != null)
            {
                throw new Exception("User_Category relationship already exists");
            }

            var user_Category = new User_Category
            {
                UserId = categoryUserDto.UserId,
                CategoryId = categoryUserDto.CategoryId
            };

            await context.User_Categories.AddAsync(user_Category);
            await context.SaveChangesAsync();
            return user_Category;
        }

        public async Task<CategoryUserDto> DeleteUser_Category(CategoryUserDto categoryUserDto)
        {
            var existingUserCategory = await context.User_Categories
                .FirstOrDefaultAsync(uc => uc.UserId == categoryUserDto.UserId && uc.CategoryId == categoryUserDto.CategoryId);
            if (existingUserCategory == null)
            {
                throw new Exception("User_Category relationship doesnt exist");
            }

            context.User_Categories.Remove(existingUserCategory);
            await context.SaveChangesAsync();
            return categoryUserDto;
        }
        public async Task<List<Category>> GetCategoriesByUserId(string userId)
        {
            var user = await context.User_Category.FirstOrDefaultAsync(c => c.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var categories = await context.User_Categories
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.Category)
                .ToListAsync();

            return categories;
        }
        public async Task<List<Category>> GetNCategoriesByUserId(string userId)
        {
            var user = await context.User_Category.FirstOrDefaultAsync(c => c.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var categories = await context.User_Categories
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.Category)
                .ToListAsync();

            var pending = await context.Category
                .Where(c => !categories.Contains(c))
                .ToListAsync();

            return pending;
        }
    }
}
