using FinanceTracker.Contracts.Transaction;
using FinanceTracker.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FinanceTracker.Services.Transaction
{
    public class TransactionService (ApplicationDbContext context , IHttpContextAccessor accessor): ITransactionService
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IHttpContextAccessor _accessor = accessor;

        public async Task CreateTransaction(TransactionRequest request,  CancellationToken cancellation)
        {
            var userId = _accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var transaction = request.Adapt<Entities.Transaction>();
            transaction!.UserId = userId!;
            var totalexpense= await _context.Dashboards.Where(x => x.UserId == userId).Select(x => x.MonthlyExpense).FirstOrDefaultAsync();
            totalexpense+= transaction.Amount;
            _context.Dashboards.Update(new Entities.Dashboard { UserId = userId!, MonthlyExpense = totalexpense });
            //Transactions.Where(x => x.UserId == userId).SumAsync(x => x.Amount);
            await _context.Transactions.AddAsync(transaction!);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TransactionResponse>> GetAllTransactions(CancellationToken cancellation)
        {
            var userId = _accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var transactions = await _context.Transactions.AsNoTracking().Where(x=>x.UserId== userId).ToListAsync();
            var response  = transactions.Adapt<IEnumerable<TransactionResponse>>();
            return response!;
        }

        public async Task<TransactionResponse?> GetTransactionById(int id, CancellationToken cancellation)
        {
            var transaction =  _context.Transactions.AsNoTracking().FirstOrDefault(x => x.Id == id);
            var response = transaction.Adapt<TransactionResponse>();
            return response!;

        }

        public async Task<bool> UpdateTransaction(int id, TransactionRequest request, CancellationToken cancellation)
        {
            var isTransactionExisted =await GetTransactionById(id , cancellation);
            if (isTransactionExisted is null)
                return false;
           
            var transaction = request.Adapt(isTransactionExisted);
            var  newTransaction = transaction.Adapt<Entities.Transaction>();
            _context.Update(newTransaction!);
            await _context.SaveChangesAsync(cancellation);
            return true;
        }
        public async Task<bool> DeleteTransaction(int id, CancellationToken cancellation)
        {
            var isTransactionExisted = await GetTransactionById(id, cancellation);
            if (isTransactionExisted is null)
                return false;

            _context.Remove(isTransactionExisted!);
            await _context.SaveChangesAsync(cancellation);
            return true;
        }
    }
}
