using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQuanAoAI.Models;
using WebQuanAoAI.Repository;

namespace WebQuanAoAI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _datacontext;
        public CategoryController(ApplicationDbContext context)
        {
            _datacontext = context;
        }
        public async Task<IActionResult>  Index(string Slug = "")

        {
            CategoryModel category = _datacontext.Categories.Where(c => c.Slug == Slug).FirstOrDefault();
            if (category == null) return RedirectToAction("Index");
            var productsByCategory = _datacontext.Products.Where(c => c.CategoryId == category.Id);

            return View(await productsByCategory.OrderByDescending(c => c.Id).ToListAsync());
        }
    }
}
