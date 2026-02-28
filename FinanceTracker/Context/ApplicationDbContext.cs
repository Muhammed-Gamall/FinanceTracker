namespace FinanceTracker.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
            public DbSet<Entities.Transaction> Transactions { get; set; } 
            public DbSet<Entities.Category> Categories { get; set; } 
            public DbSet<Entities.Budget> Budgets { get; set; } 
            public DbSet<Entities.Dashboard> Dashboards { get; set; } 
    }
}
