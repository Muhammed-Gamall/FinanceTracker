using FinanceTracker.Contracts.Transaction;

namespace FinanceTracker.Services.Transaction
{
    public interface ITransactionService
    {
        Task CreateTransaction(TransactionRequest request, CancellationToken cancellation);
        Task<IEnumerable<TransactionResponse>> GetAllTransactions(CancellationToken cancellation);
        Task<TransactionResponse?> GetTransactionById(int id ,CancellationToken cancellation);
        Task<bool> UpdateTransaction(int id , TransactionRequest request, CancellationToken cancellation);
        Task<bool> DeleteTransaction(int id , CancellationToken cancellation);
    }
}
