using Microsoft.AspNetCore.Mvc;

namespace WebQuanAoAI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
