namespace FinanceTracker.Contracts.Transaction
{
    public record TransactionResponse
    (
        int Id,
        string Description,
         decimal Amount,
          int CategoryId,
          string UserId

    );
}
