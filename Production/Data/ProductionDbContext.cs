using Production.Modals;
using Microsoft.EntityFrameworkCore;

namespace Production.Data
{
    public class ProductionDbContext : DbContext
    {
        public ProductionDbContext(DbContextOptions<ProductionDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<ProductionFloor> ProductionFloors { get; set; }
        public DbSet<FlowWorker> FlowWorkers { get; set; }
    }
}
