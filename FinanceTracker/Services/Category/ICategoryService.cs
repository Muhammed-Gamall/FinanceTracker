namespace FinanceTracker.Services.Category
{
    public interface ICategoryService
    {
            Task<Entities.Category?> GetCategoryByIdAsync(int id , CancellationToken cancellation);
            Task CreateCategoryAsync(CategoryRequest request, CancellationToken cancellation);
            Task<bool> UpdateCategoryAsync(CategoryRequest request, int id, CancellationToken cancellation);
            Task<bool> DeleteCategoryAsync(int id, CancellationToken cancellation);
    }
}
