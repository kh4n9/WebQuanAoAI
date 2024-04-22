using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQuanAoAI.Repository;

namespace WebQuanAoAI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.OrderByDescending(p => p.Id).ToListAsync());
        }
        public async Task<IActionResult> ViewOrder(string ordercode)
        {
            var detailsOrder = await _context.OrderDetails.Include(o => o.Product).Where(o => o.OrderCode == ordercode).ToListAsync();
            return View(detailsOrder);
        }
    }
}
