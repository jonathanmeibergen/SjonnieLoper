using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SjonnieLoper.Core;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Whiskey> Whiskeys { get; set; }
        public DbSet<WhiskeyType> WhiskeyTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Storage> Storage { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            ApplicationUser AppUser = new ApplicationUser {
                //EmployeeNumber = 1,
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = true
            };
            AppUser.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(AppUser, "Admin-1234");

            builder.Entity<ApplicationUser>().HasData(AppUser);

            builder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>{
                Id = 1,
                UserId = AppUser.Id,
                ClaimType = "Role",
                ClaimValue = "Admin"
            });

        }
    }
}