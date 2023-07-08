using AutoMapper;
using Charity_API.Data;
using Charity_API.Data.DTOs;
using Charity_API.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Charity_API.Services
{
    public class UserService
    {

        private readonly UserManager<User> userManager;
        private IConfiguration configuration;
        private readonly AppDbContext context;

        public UserService(UserManager<User> userManager, IConfiguration configuration, AppDbContext context)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.context = context;
        }

        public async Task<bool> Register(RegisterDto user)
        {
            var u = await userManager.FindByNameAsync(user.UserName);
            if (u != null)
            {
                throw new Exception("User already exists");
            }

            User us = new User();
            if (user.RoleId == 4)
            {
                us = new User
                {
                    UserName = user.UserName,
                    Email = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RoleId = user.RoleId,
                    City = user.City,
                    Address = user.Address,
                    Birthday = user.Birthday,
                    Approved = true,
                    Status = null

                };
            }
            else if (user.RoleId == 2)
            {
                us = new User
                {
                    UserName = user.UserName,
                    Email = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RoleId = user.RoleId,
                    City = user.City,
                    Address = user.Address,
                    Birthday = user.Birthday,
                    Approved = false,
                    Status = null
                };

            }
            else if (user.RoleId == 3)
            {
                us = new User
                {
                    UserName = user.UserName,
                    Email = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RoleId = user.RoleId,
                    City = user.City,
                    Address = user.Address,
                    Birthday = user.Birthday,
                    Approved = false,
                    Status = user.Status
                };
            }
            else
            {
                throw new Exception("Smoething went wrong");
            }

                var result = await userManager.CreateAsync(us, user.Password);
                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        public async Task<object> Login(LoginDto user)
        {
            var u = await userManager.FindByNameAsync(user.UserName);
            if (u == null)
            {
                throw new Exception("User does not exists");
            }
            if (!u.Approved)
            {
                throw new Exception("User is not approved");
            }

            if (await userManager.CheckPasswordAsync(u, user.Password))
            {
                var signKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("78fUjkyzfLz56gTq"));
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                };

                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(2),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256)
                    );
                var toReturn = new JwtSecurityTokenHandler().WriteToken(token);
                var obj = new
                {
                    expires = DateTime.Now.AddHours(2),
                    token = toReturn,
                    user = u
                };
                return obj;
            }
            else
            {
                throw new Exception("Username and password do not match");
            }
        }

        //approve employee
        public async Task<bool> ApproveUser(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("user not found");
            }

            user.Approved = true;

            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                throw new Exception("something went wrong");
            }
        }
        public async Task<User> GetUser(string userId)
        {
            var u = await userManager.FindByIdAsync(userId);
            if (u == null)
            {
                throw new Exception("User not found");
            }
            return u;
        }
        public async Task<bool> DeleteUser(string userId)
        {
            var u = await userManager.FindByIdAsync(userId);
            if (u == null)
            {
                throw new Exception("User not found");
            }
            var result = await userManager.DeleteAsync(u);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                throw new Exception("Something went wrong");
            }
        }
        public async Task<User> UpdateUser(string userId, UpdateUserDto user)
        {
            var u = await userManager.FindByIdAsync(userId);
            if (u == null)
            {
                throw new Exception("User not found");
            }
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.City = user.City;
            u.Address = user.Address;
            u.Birthday = user.Birthday;
            u.Image = user.Image;
            var result = await userManager.UpdateAsync(u);
            if (result.Succeeded)
            {
                return u;
            }
            else
            {
                throw new Exception("Something went wrong");
            }
        }
        public async Task<List<User>> GetDonators()
        {
            var list = context.Users.Where(x => x.RoleId == 3).ToList();
            return list;
        }
        public async Task<List<User>> GetBenefitiaries()
        {
            var list = context.Users.Where(x => x.RoleId == 4).ToList();
            return list;
        }
        public async Task<List<User>> GetCouriers()
        {
            var list = context.Users.Where(x => x.RoleId == 2).ToList();
            return list;
        }


        public async Task<bool> ChangePassword(string userId, ChangePasswordDto user)
        {
            var u = await userManager.FindByIdAsync(userId);
            if (u == null)
            {
                throw new Exception("User not found");
            }
            var result = await userManager.ChangePasswordAsync(u, user.OldPassword, user.NewPassword);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                throw new Exception("Something went wrong");
            }
        }

        public async Task<bool> ChangeVisibility(string userId)
        {
            var u = await userManager.FindByIdAsync(userId);
            if (u == null)
            {
                throw new Exception("User not found");
            }

            u.Status = !u.Status;

            var result = await userManager.UpdateAsync(u);
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                throw new Exception("Something went wrong");
            }
        }
    }
}
