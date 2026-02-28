

namespace FinanceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController(ITransactionService transactionService) : ControllerBase
    {
        private readonly ITransactionService _transactionService = transactionService;


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetTransactions(CancellationToken cancellation)
        {
            var response = await _transactionService.GetAllTransactions(cancellation);
            return response is null ? NotFound() : Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(int id, CancellationToken cancellation)
        {
            var response = await _transactionService.GetTransactionById(id, cancellation);
            return response is null ? NotFound() : Ok(response);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionRequest request, CancellationToken cancellation)
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _transactionService.CreateTransaction(request, cancellation);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TransactionRequest request, CancellationToken cancellation)
        {
            var transaction = await _transactionService.UpdateTransaction(id, request, cancellation);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, TransactionRequest request, CancellationToken cancellation)
        {
            var transaction = await _transactionService.DeleteTransaction(id, cancellation);
            return Ok();
        }

        //[Authorize]
        //[HttpPost("seed")]
        //public async Task<IActionResult> Seed(CancellationToken cancellation)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    return Ok(userId);
        //}
    }
}
