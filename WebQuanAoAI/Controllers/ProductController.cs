using Microsoft.AspNetCore.Mvc;

namespace WebQuanAoAI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
