using Identity.Modals;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DateTime now = DateTime.Now;

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    CompanyId = 1,
                    AuthId = 1,
                    UserIdentifier = "6872a1be-fe5e-4d2b-8ac1-26ce0c36f846",
                    FirstName = "InfoPro",
                    LastName = "Admin",
                    Email = "tharindutd1998@gmail.com",
                    Phone = "0779200039",

                    IsDeleted = false,
                    CreatedOn = now,
                    UpdatedOn = now,
                });

            modelBuilder.Entity<Company>()
                .HasData(new Company
                {
                    Id = 1,
                    CompanyName = "InfoPro",
                    AddressLine1 = "No 271",
                    AddressLine2 = "Main Street",
                    City = "Matara",
                    PostalCode = "81000",
                    CompanyEmail = "tharindutd1998@gmail.com",
                    CompanyContact = "0779200039",
                    Website = "infopro.com",
                    AdminIdentifire = "6872a1be-fe5e-4d2b-8ac1-26ce0c36f846",
                    IsDeleted = false,
                    CreatedOn = now,
                    UpdatedOn = now,
                }) ;
        }
    }
}
