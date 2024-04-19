using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQuanAoAI.Models;
using WebQuanAoAI.Repository;

namespace WebQuanAoAI.Controllers
{
    public class BrandController : Controller

    {
        private readonly ApplicationDbContext _datacontext;
        public BrandController(ApplicationDbContext context)
        {
            _datacontext = context;
        }
        public async Task<IActionResult> Index(string Slug = "")

        {
            BrandModel brand = _datacontext.Brands.Where(c => c.Slug == Slug).FirstOrDefault();
            if (brand == null) return RedirectToAction("Index");
            var productsByBrand = _datacontext.Products.Where(p => p.BrandId == brand.Id);

            return View(await productsByBrand.OrderByDescending(p => p.Id).ToListAsync());
        }
    }
}
