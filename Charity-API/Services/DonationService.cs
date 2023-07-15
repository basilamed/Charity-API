using Charity_API.Data.Models;
using Charity_API.Data;
using Microsoft.AspNetCore.Identity;
using Charity_API.Data.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            var user = await context.User_Category.FirstOrDefaultAsync(c => c.Id == userId);
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
        public async Task<List<Donation>> GetDonationsByCategoryId(int Id)
        {
            var c = await context.Category.FirstOrDefaultAsync(c => c.Id == Id);
            if (c == null)
            {
                throw new Exception("Category not found");
            }

            var donations = await context.Donations
                .Where(uc => uc.CategoryId == Id && uc.LeftoverAmount > 0)
                .Include(c => c.Category)
                .ToListAsync();

            return donations;
        }
        public async Task<double> GetTotalAmountReceivedByBeneficiary(string userId, int categoryId)
        {
            var totalAmount = await context.Donation_Benefitiaries
                .Where(db => db.BenefitiaryId == userId && db.Donation.CategoryId == categoryId)
                .SumAsync(db => db.Amount);

            return totalAmount;
        }
        public async Task<Donation_Benefitiary> CreateDonator_Benefitiary(DonationBenefitiaryDto donationBenefitiaryDto)
        {
            var donation = await context.Donations.FirstOrDefaultAsync(c => c.DonationId == donationBenefitiaryDto.DonationId);
            if (donation == null)
            {
                throw new Exception("Donation not found");
            }
            if (donation.LeftoverAmount == 0)
            {
                throw new Exception("Donation has been fully spent");
            }
            if (donation.LeftoverAmount < donationBenefitiaryDto.Amount)
            {
                throw new Exception("The amount you are trying to give cannot be given");
            }

            var user = await context.User_Category.FirstOrDefaultAsync(d => d.Id == donationBenefitiaryDto.BenefitiaryId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var existingUserCategory = await context.User_Categories
                .FirstOrDefaultAsync(uc => uc.UserId == donationBenefitiaryDto.BenefitiaryId && uc.CategoryId == donation.CategoryId);
            if (existingUserCategory == null)
            {
                throw new Exception("User_Category relationship doesnt exist");
            }

            var donation_User = new Donation_Benefitiary
            {
                Date = DateTime.UtcNow,
                DonationId = donationBenefitiaryDto.DonationId,
                BenefitiaryId = donationBenefitiaryDto.BenefitiaryId,
                Amount = donationBenefitiaryDto.Amount
            };

            donation.LeftoverAmount -= donation_User.Amount;

            await context.Donation_Benefitiaries.AddAsync(donation_User);
            await context.SaveChangesAsync();
            return donation_User;
        }

    }
}
