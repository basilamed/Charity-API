using Charity_API.Data.Models;
using Charity_API.Data;
using Microsoft.AspNetCore.Identity;
using Charity_API.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Charity_API.Services
{
    public class DonationService
    {

        private readonly AppDbContext context;
        private readonly ILogger<DonationService> logger;

        public DonationService( AppDbContext context, ILogger<DonationService> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public async Task AddDonation(DonationDto donation)
        {
            var d = new Donation
            {
                DonationDate = DateTime.UtcNow,
                DonationAmount = donation.DonationAmount,
                LeftoverAmount = donation.DonationAmount,
                DonatorId = donation.DonatorId,
                CategoryId = donation.CategoryId
            };
            context.Donations.Add(d);

            await context.SaveChangesAsync();
        }
        public async Task<List<Donation>> GetAllDonations()
        {
            var list = await context.Donations.ToListAsync();
            return list;
        }
        public async Task<List<Donation>> GetDonationsByDonatorId(string userId)
        {
            var user = await context.User.FirstOrDefaultAsync(c => c.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var donations = await context.Donations
                .Where(uc => uc.DonatorId == userId)
                .Include(c => c.Category)
                .ToListAsync();

            return donations;
        }

        public async Task<Donation> GetDonationsById(int id)
        {
            var donation = await context.Donations.FirstOrDefaultAsync(c => c.DonationId == id);
            if (donation == null)
            {
                throw new Exception("Donation not found");
            }

            var donations = await context.Donations
                .Where(uc => uc.DonationId == id)
                .FirstAsync();

            return donations;
        }
        //public async Task<List<Donation>> GetDonationsByBenefitiaryId(string userId)
        //{ 
        //    var user = await context.User.FirstOrDefaultAsync(c => c.Id == userId);
        //    if (user == null)
        //    {
        //        throw new Exception("User not found");
        //    }

        //    var donations = await context.Donations
        //        .Where(uc => uc.Benefitiary.Contains(user))
        //        .ToListAsync();

        //    return donations;
        //}

    }
}
