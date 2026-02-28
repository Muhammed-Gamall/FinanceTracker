
namespace FinanceTracker
{
    public static class Dependancies
    {
        public static IServiceCollection AddDependancies (this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddOpenApi();
            services.AddScoped<Services.Category.ICategoryService, Services.Category.CategoryService>();
            services.AddScoped<Services.Transaction.ITransactionService, Services.Transaction.TransactionService>();
            services.AddScoped<Services.Dashboard.IDashboardService, Services.Dashboard.DashboardService>();

            return services;
        }
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
