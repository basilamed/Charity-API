using Charity_API.Data;
using Charity_API.Data.DTOs;
using Charity_API.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Charity_API.Services
{
    public class NoteService
    {
        private readonly AppDbContext context;

        public NoteService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Note> AddNote(NoteDto category)
        {
            var c = new Note
            {
                DateTime = DateTime.UtcNow,
                Text = category.Text,
                Review = category.Review
            };
            context.Notes.Add(c);

            await context.SaveChangesAsync();
            return c;
        }
        public async Task<bool> ChangeVisibility(int id)
        {
            var u = await context.User_Donators_Notes.FirstOrDefaultAsync(c => c.Id == id);
            if (u == null)
            {
                throw new Exception("User not found");
            }
            u.Seen = !u.Seen;

            var result = await context.SaveChangesAsync();
            if (result == null)
            {
                throw new Exception("Something went wrong");
            }
            return u.Seen;
        }
        public async Task<List<Note>> GetNotesByUserId(string userId)
        {
            var user = await context.User_Donators_Notes.FirstOrDefaultAsync(c => c.UserId == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var notes = await context.User_Donators_Notes
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.Note)
                .ToListAsync();

            return notes;
        }
        public async Task<List<Note>> GetNotesByDonatorId(string userId)
        {
            var user = await context.User_Donators_Notes.FirstOrDefaultAsync(c => c.DonatorId == userId);
            if (user == null)
            {
                throw new Exception("Donator not found");
            }

            var notes = await context.User_Donators_Notes
                .Include(uc => uc.Note.Notes)
                .Where(uc => uc.DonatorId == userId && !uc.Seen)
                .Select(uc => uc.Note)
                .ToListAsync();

            return notes;
        }
        public async Task<List<Note>> GetNotesByDonationBenefitiaryId(int id)
        {
            var user = await context.User_Donators_Notes.FirstOrDefaultAsync(c => c.Donation_Benefitiary_Id == id);
            if (user == null)
            {
                throw new Exception("DonationBenefitiary not found");
            }

            var notes = await context.User_Donators_Notes
                .Where(uc => uc.Donation_Benefitiary_Id == id)
                .Select(uc => uc.Note)
                .ToListAsync();

            return notes;
        }
        public async Task<User_Donator_Note> CreateUser_Donator_Note(SendNoteDto dto)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(c => c.Id == dto.UserId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }

                var donator = await context.Users.FirstOrDefaultAsync(c => c.Id == dto.DonatorId);
                if (donator == null)
                {
                    throw new Exception("Donator not found");
                }

                var donation = await context.Donation_Benefitiaries.FirstOrDefaultAsync(c => c.Id == dto.Donation_Benefitiary_Id);
                if (donation == null)
                {
                    throw new Exception("Donation_Benefitiary not found");
                }

                var note = await context.Notes.FirstOrDefaultAsync(d => d.Id == dto.NoteId);
                if (note == null)
                {
                    throw new Exception("Note not found");
                }

                var existingUserCategory = await context.User_Donators_Notes
                    .FirstOrDefaultAsync(uc => uc.UserId == dto.UserId &&
                                               uc.DonatorId == dto.DonatorId &&
                                               uc.NodeId == dto.NoteId &&
                                               uc.Donation_Benefitiary_Id == dto.Donation_Benefitiary_Id);
                if (existingUserCategory != null)
                {
                    throw new Exception("The user already sent a thank you note to the donator for the given donation");
                }

                var user_Donator_Note = new User_Donator_Note
                {
                    UserId = dto.UserId,
                    DonatorId = dto.DonatorId,
                    NodeId = dto.NoteId,
                    Donation_Benefitiary_Id = dto.Donation_Benefitiary_Id,
                    Seen = false
                };

                await context.User_Donators_Notes.AddAsync(user_Donator_Note);
                await context.SaveChangesAsync();

                return user_Donator_Note;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("An error occurred while saving the entity changes. See the inner exception for details.");
            }
        }
    }
}
