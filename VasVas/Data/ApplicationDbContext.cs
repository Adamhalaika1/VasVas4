using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VasVas.Models;

namespace VasVas.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("users", "Security");
                //.Ignore(e => e.UserName)
                //.Ignore(e => e.NormalizedEmail)
                //.Ignore(e => e.NormalizedUserName)
                //.Ignore(e => e.SecurityStamp)
                //.Ignore(e => e.ConcurrencyStamp)
                //.Ignore(e => e.TwoFactorEnabled)
                //.Ignore(e => e.LockoutEnabled)
                //.Ignore(e => e.LockoutEnd)
                //.Ignore(e => e.AccessFailedCount)
                //.Ignore(e => e.EmailConfirmed)
                //.Ignore(e => e.PhoneNumberConfirmed);


            builder.Entity<IdentityRole>().ToTable("Roles", "Security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "Security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "Security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "Security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "Security");
        }
    }
}