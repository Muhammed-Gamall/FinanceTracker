namespace FinanceTracker.Contracts.Dashboard
{
    public record DashboardResponse
    (    
        decimal TotalBalance,
        decimal MonthlyIncome,
        decimal MonthlyExpense,
        decimal Savings
    );
}
