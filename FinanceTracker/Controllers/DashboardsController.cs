using FinanceTracker.Services.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardsController(IDashboardService service) : ControllerBase
    {
        private readonly IDashboardService _service = service;
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetDashboard(CancellationToken cancellation)
        {
            var dashboard = await _service.GetDashboard(cancellation);
            return dashboard is null ? NotFound() : Ok(dashboard);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(DashboardRequest request, CancellationToken cancellation)
        {
            await _service.Create(request, cancellation);
            return Ok();
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(DashboardRequest request, CancellationToken cancellation)
        {
            await _service.Update(request, cancellation);
            return Ok();
        }
    }
}
