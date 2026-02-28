namespace FinanceTracker.Entities
{
    public class Dashboard
    {
        public int Id { get; set; }
        public decimal TotalBalance { get; set; } = 0;
        public decimal MonthlyIncome { get; set; } = 0 ;
        public decimal MonthlyExpense { get; set; } = 0 ;
        public decimal Savings => MonthlyIncome - MonthlyExpense;


        public required string UserId { get; set; }
        public IdentityUser User { get; set; } = default!;
    }
}
