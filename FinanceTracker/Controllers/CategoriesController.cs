using FinanceTracker.Services.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryRequest request, CancellationToken cancellation)
        {
            await _categoryService.CreateCategoryAsync(request, cancellation);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryRequest request, CancellationToken cancellation)
        {
            var isUpdated = await _categoryService.UpdateCategoryAsync(request, id, cancellation);
            if (!isUpdated)
                return NotFound();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id, CancellationToken cancellation)
        {
            var isDeleted = await _categoryService.DeleteCategoryAsync(id, cancellation);
            if (!isDeleted)
                return NotFound();
            return Ok();

        }
    }
}
