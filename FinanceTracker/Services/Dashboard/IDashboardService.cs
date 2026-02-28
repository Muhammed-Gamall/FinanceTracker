
namespace FinanceTracker.Services.Dashboard
{
    public interface IDashboardService
    {
            Task<DashboardResponse?> GetDashboard(CancellationToken cancellation = default);
            Task Create(DashboardRequest request , CancellationToken cancellation = default);
            Task Update(DashboardRequest request , CancellationToken cancellation = default);
    }
}
