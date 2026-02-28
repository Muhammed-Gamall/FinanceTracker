using Microsoft.AspNetCore.Identity;

namespace FinanceTracker.Entities
{
    public class Budget
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

        public required string UserId { get; set; }
        public IdentityUser User { get; set; } = default!;
        ///public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

    }
}
