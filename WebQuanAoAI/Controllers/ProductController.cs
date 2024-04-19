using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQuanAoAI.Repository;

namespace WebQuanAoAI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _datacontext;
        public ProductController(ApplicationDbContext datacontext)
        {
            _datacontext = datacontext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int Id)
        {
            if (Id == null) return RedirectToAction("Index");
            var productsById = _datacontext.Products.Where(c => c.Id == Id).Include("Category").Include("Brand").FirstOrDefault();
            return View(productsById);
        }
    }
}
