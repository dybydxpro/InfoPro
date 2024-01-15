using Identity.Modals;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DateTime now = DateTime.Now;

            //modelBuilder.Entity<User>()
            //    .HasData(new User
            //    {
            //        Id = 1,
            //        AuthId = 1,
            //        UserIdentifier = "ad2a97bf-fc14-4a2a-a932-61a43c33c2d4",
            //        FirstName = "Tharindu",
            //        LastName = "Theekshana",
            //        UserName = "TharuBro",
            //        Email = "tharindutd1998@gmail.com",

            //        IsDeleted = false,
            //        CreatedOn = now,
            //        UpdatedOn = now,
            //    });
        }
    }
}
