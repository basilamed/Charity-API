using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Charity_API.Data.Models;
using System.Data;

namespace Charity_API.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<User_Category>()
                .HasOne(c => c.Category)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.CategoryId);

            modelBuilder.Entity<User_Category>()
                .HasOne(u => u.User)
                .WithMany(c => c.Categories)
                .HasForeignKey(ci => ci.UserId);

            modelBuilder.Entity<User_Donator_Note>()
                .HasOne(u => u.Benefitiary)
                .WithMany(n => n.UsersNotes)
                .HasForeignKey(ni => ni.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User_Donator_Note>()
                .HasOne(u => u.Donator)
                .WithMany(n => n.DonatorsNotes)
                .HasForeignKey(ni => ni.DonatorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Donation_Benefitiary>()
                .HasOne(u => u.Donation)
                .WithMany(b => b.Benefitiaries)
                .HasForeignKey(bi => bi.DonationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Donation_Benefitiary>()
                .HasOne(u => u.Benefitiary)
                .WithMany(b => b.Donation)
                .HasForeignKey(bi => bi.BenefitiaryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.RoleId);
            

        }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> User_Category { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet <Donation> Donations { get; set; }
        public DbSet<User_Category> User_Categories { get; set; }
        public DbSet<User_Donator_Note> User_Donators_Notes { get; set;}
        public DbSet<Donation_Benefitiary> Donation_Benefitiaries { get; set; }

    }
}
