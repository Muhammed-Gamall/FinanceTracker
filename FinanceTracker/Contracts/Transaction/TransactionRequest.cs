namespace FinanceTracker.Contracts.Transaction
{
    public record TransactionRequest
    (
        string Description ,
         decimal Amount,
          int CategoryId
          //string UserId
    );
}
