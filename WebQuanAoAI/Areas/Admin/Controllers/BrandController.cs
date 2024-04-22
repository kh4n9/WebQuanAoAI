using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebQuanAoAI.Models;
using WebQuanAoAI.Repository;

namespace WebQuanAoAI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class Brand : Controller
    {
        private readonly ApplicationDbContext _context;
        public Brand(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Brands.OrderByDescending(p => p.Id).ToListAsync());
        }
        public async Task<IActionResult> Edit(int Id)
        {
            BrandModel brand = await _context.Brands.FindAsync(Id);

            return View(brand);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandModel brand)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Brand ok phết";
                brand.Slug = brand.Name.Replace(" ", "-");
                var slug = await _context.Brands.FirstOrDefaultAsync(p => p.Slug == brand.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Brand vừa thêm đã tồn tại");
                    return View(brand);
                }
                _context.Add(brand);
                await _context.SaveChangesAsync();
                TempData["success"] = "Thêm nhãn hàng thành công";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["error"] = "Có một số thứ đang bị lỗi";
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);
            }

            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BrandModel brand)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Brand ok phết";
                brand.Slug = brand.Name.Replace(" ", "-");
                var slug = await _context.Brands.FirstOrDefaultAsync(p => p.Slug == brand.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Brand vừa thêm đã tồn tại");
                    return View(brand);
                }
                _context.Update(brand);
                await _context.SaveChangesAsync();
                TempData["success"] = "Thêm nhãn hàng thành công";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["error"] = "Có một số thứ đang bị lỗi";
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);
            }

            return View(brand);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            BrandModel brand = await _context.Brands.FindAsync(Id);

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            TempData["success"] = "Xóa nhãn hàng thành công";
            return RedirectToAction("Index");
        }
    }
}
