using Microsoft.AspNetCore.Mvc;

namespace WebQuanAoAI.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
