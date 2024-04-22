using Microsoft.AspNetCore.Mvc;
using WebQuanAoAI.Models;
using WebQuanAoAI.Models.ViewModels;
using WebQuanAoAI.Repository;

namespace WebQuanAoAI.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            CartItemViewModel cartItem = new()
            {
                CartItems = cartItems,
                GrandTotal = cartItems.Sum(x => x.Quantity * x.Price)
            };
            return View(cartItem);
        }
        
        public IActionResult CheckOut()
        {
            return View("~/Views/Checkout/Index.cshtml");
        }
        public async Task<IActionResult> AddToCart(int Id)
        {
            ProductModel productModel = await _context.Products.FindAsync(Id);
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            CartItemModel cartItem = cart.Where(c => c.ProductId == Id).FirstOrDefault();
            if (cartItem == null)
            {
                cart.Add(new CartItemModel(productModel));
            }
            else
            {
                cartItem.Quantity += 1;
            }
            HttpContext.Session.SetJson("Cart", cart);
            TempData["success"] = "Add Item To Cart Success";
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> Decrease(int Id)
        {
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");

            CartItemModel cartItemModel = cart.Where(c => c.ProductId == Id).FirstOrDefault();

            if (cartItemModel.Quantity > 1)
            {
                --cartItemModel.Quantity;
            }
            else
            {
                cart.RemoveAll(c => c.ProductId == Id);
            }
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            TempData["success"] = "Decrease Item Success";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Inscrease(int Id)
        {
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");

            CartItemModel cartItemModel = cart.Where(c => c.ProductId == Id).FirstOrDefault();

            if (cartItemModel.Quantity >= 1)
            {
                ++cartItemModel.Quantity;
            }
            else
            {
                cart.RemoveAll(c => c.ProductId == Id);
            }
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            TempData["success"] = "Inscrease Item Success";

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Remove(int Id)
        {
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
            cart.RemoveAll(p => p.ProductId == Id);
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            TempData["success"] = "Remove Item Success";

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Clear()
        {
            HttpContext.Session.Remove("Cart");
            TempData["success"] = "Remove All Item Success";

            return RedirectToAction("Index");
        }
    }
}
