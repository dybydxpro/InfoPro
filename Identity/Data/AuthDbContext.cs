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

            //modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            //{
            //    Id = "ad2a97bf-fc14-4a2a-a932-61a43c33c2d4",
            //    AuthId = 1,
            //    FirstName = "InfoPro",
            //    LastName = "Admin",
            //    UserName = "",
            //    NormalizedUserName = "",
            //    Email = "Admin",
            //    NormalizedEmail = "ADMIN",
            //    EmailConfirmed = true,
            //    PasswordHash = "AQAAAAIAAYagAAAAEObLLxLkH+6vKjFFpO2IBwa4GEhC8M5xNaoL96P0iq8kaN9xlblLVXf63NXLO9GwSg==",
            //    SecurityStamp = "JDHZZFYQIRO723UUPC57WQJOGKU35NL5",
            //    ConcurrencyStamp = "b7bce4e8-ec2d-4551-9f70-54abcd5fdde5",
            //    PhoneNumber = null,
            //    PhoneNumberConfirmed = false,
            //    TwoFactorEnabled = false,
            //    LockoutEnd = null,
            //    LockoutEnabled = true,
            //    AccessFailedCount = 0,
            //});

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
