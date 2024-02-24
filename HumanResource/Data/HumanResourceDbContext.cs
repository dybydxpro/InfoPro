using HumanResource.Models;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.Data
{
    public class HumanResourceDbContext: DbContext
    {
        public HumanResourceDbContext(DbContextOptions<HumanResourceDbContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}