using Duende.IdentityServer.EntityFramework.Options;
using Identity.Modals;
using Identity.Modals.Auth;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Identity.Data
{
    public class AuthDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.Property(e => e.AuthId).Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = "6872a1be-fe5e-4d2b-8ac1-26ce0c36f846",
                AuthId = 1,
                FirstName = "InfoPro",
                LastName = "Admin",
                UserName = "tharindutd1998@gmail.com",
                NormalizedUserName = "THARINDUTD1998@GMAIL.COM",
                Email = "tharindutd1998@gmail.com",
                NormalizedEmail = "THARINDUTD1998@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEO2NZlDTC/AeRvEjQo61i7uEks7JlX0uxUFaBUIQlLiGiSZxHu7uIW43BUEoxe1fAA==",
                SecurityStamp = "ENOMQ2ITQD77EWDHLT572ZGEFSI3GDOO",
                ConcurrencyStamp = "776c7622-8ad0-484c-bf59-fb390dda1389",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                ImageUrl = null,
            }) ;

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "1",
                    Name = ApplicationRoles.SUPER_ADMIN,
                    NormalizedName = "SuperAdmin"
                },
                new IdentityRole()
                {
                    Id = "2",
                    Name = ApplicationRoles.HR_ADMIN,
                    NormalizedName = "HRAdmin"
                });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
