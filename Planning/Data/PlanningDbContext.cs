using Microsoft.EntityFrameworkCore;
using Planning.Models;

namespace Planning.Data;

public class PlanningDbContext : DbContext
{
    public PlanningDbContext(DbContextOptions<PlanningDbContext> options) : base(options) {}
    
    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }
}