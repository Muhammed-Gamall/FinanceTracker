using Microsoft.AspNetCore.Identity;

namespace FinanceTracker.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount     { get; set; }
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);


        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

        public required string UserId { get; set; }
        public IdentityUser User { get; set; } = default!;
    }
}
