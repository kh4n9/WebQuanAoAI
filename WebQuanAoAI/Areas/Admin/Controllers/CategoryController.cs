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
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.OrderByDescending(p => p.Id).ToListAsync());
        }
        public async Task<IActionResult> Edit(int Id)
        {
            CategoryModel category = await _context.Categories.FindAsync(Id);

            return View(category);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryModel Category)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Category ok phết";
                Category.Slug = Category.Name.Replace(" ", "-");
                var slug = await _context.Categories.FirstOrDefaultAsync(p => p.Slug == Category.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Category vừa thêm đã tồn tại");
                    return View(Category);
                }
                _context.Add(Category);
                await _context.SaveChangesAsync();
                TempData["success"] = "Thêm danh mục thành công";
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

            return View(Category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Category ok phết";
                category.Slug = category.Name.Replace(" ", "-");
                var slug = await _context.Categories.FirstOrDefaultAsync(p => p.Slug == category.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Category vừa thêm đã tồn tại");
                    return View(category);
                }
                _context.Update(category);
                await _context.SaveChangesAsync();
                TempData["success"] = "Thêm danh mục thành công";
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

            return View(category);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            CategoryModel category = await _context.Categories.FindAsync(Id);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            TempData["success"] = "Xóa danh mục thành công";
            return RedirectToAction("Index");
        }
    }
}
