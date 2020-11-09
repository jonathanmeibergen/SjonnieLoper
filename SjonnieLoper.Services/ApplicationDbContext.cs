using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SjonnieLoper.Services.DataModels;

namespace SjonieLoper.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Whiskey> Whiskeys { get; set; }
        public DbSet<WhiskeyType> WhiskeyTypes { get; set; }

        /*protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Whiskey>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            base.OnModelCreating(builder);
        }*/
    }
}