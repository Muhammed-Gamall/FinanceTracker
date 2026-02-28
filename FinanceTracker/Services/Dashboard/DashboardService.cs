using Mapster;

namespace FinanceTracker.Services.Dashboard
{
    public class DashboardService(ApplicationDbContext context, IHttpContextAccessor accessor) : IDashboardService
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IHttpContextAccessor _accessor = accessor;

        public async Task<DashboardResponse?> GetDashboard(CancellationToken cancellation = default)
        {
            var userId = _accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var query = _context.Dashboards.AsNoTracking().Where(d => d.UserId == userId);


            var totalBalance = await query.SumAsync(d => d.TotalBalance, cancellation);
            var monthlyIncome = await query.SumAsync(d => d.MonthlyIncome, cancellation);
            var monthlyExpense = await query.SumAsync(d => d.MonthlyExpense, cancellation);
            var savings = monthlyIncome - monthlyExpense;

            var response = new DashboardResponse(
                totalBalance,
                monthlyIncome,
                monthlyExpense,
                savings
                );
            return response;
        }

        public async Task Create(DashboardRequest request, CancellationToken cancellation = default)
        {
            var userId = _accessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dashboard = request.Adapt<Entities.Dashboard>();
            dashboard!.UserId = userId!;
           await _context.Dashboards.AddAsync(dashboard);
            await _context.SaveChangesAsync();
             return;
        }


        public async Task Update(DashboardRequest request, CancellationToken cancellation = default)
        {
            var userId = _accessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dashboard =await _context.Dashboards.FirstOrDefaultAsync(d => d.UserId == userId);
            var updatedDashboard = request.Adapt(dashboard);
            _context.Dashboards.Update(updatedDashboard!);
            await _context.SaveChangesAsync(cancellation);
            return;
        }
    }
}
