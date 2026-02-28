using Mapster;

namespace FinanceTracker.Services.Category
{
    public class CategoryService(ApplicationDbContext context) : ICategoryService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task CreateCategoryAsync(CategoryRequest request,CancellationToken cancellation)
        {
            var category = request.Adapt<Entities.Category>();
            await _context.Categories.AddAsync(category!, cancellation);
            await _context.SaveChangesAsync( cancellation );
        }

        public async Task<Entities.Category?> GetCategoryByIdAsync(int id, CancellationToken cancellation)
        {
            var category = _context.Categories.AsNoTracking().FirstOrDefault(c => c.Id== id);
            return category;
        }
        public async Task<bool> DeleteCategoryAsync(int id, CancellationToken cancellation)
        {
            var category= await GetCategoryByIdAsync(id, cancellation);
            if (category is null)
                return false;
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(cancellation);
            return true;
        }

        public async Task<bool> UpdateCategoryAsync(CategoryRequest request, int id, CancellationToken cancellation)
        {
            var category = await GetCategoryByIdAsync(id, cancellation);
            if (category is null)
                return false;
            var updatedCategory = request.Adapt(category);
            _context.Categories.Update(updatedCategory!);
            await _context.SaveChangesAsync(cancellation);
            return true;
        }
    }
}
