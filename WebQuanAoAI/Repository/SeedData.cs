using Microsoft.EntityFrameworkCore;
using WebQuanAoAI.Models;

namespace WebQuanAoAI.Repository
{
    public class SeedData
    {
        public static void SeedingData(ApplicationDbContext _context)
        {
            _context.Database.Migrate();
            if (!_context.Products.Any())
            {
                CategoryModel laptop = new CategoryModel { Name = "Apple", Slug = "apple", Description = "Apple is Large Brand in the world", Status = 1 };
                CategoryModel pc = new CategoryModel { Name = "Samsung", Slug = "samsung", Description = "Samsung is Large Brand in the world", Status = 1 };
                BrandModel apple = new BrandModel { Name = "Apple", Slug = "apple", Description = "Apple is Large Brand in the world", Status = 1 };
                BrandModel samsung = new BrandModel { Name = "Samsung", Slug = "samsung", Description = "Samsung is Large Brand in the world", Status = 1 };
                _context.Products.AddRange(
                    new ProductModel { Name = "laptop", Slug = "laptop", Description = "laptop is the best", Image = "1.jpg", Category = laptop, Brand = apple, Price = 1234 },
                    new ProductModel { Name = "pc", Slug = "pc", Description = "pc is the best", Image = "1.jpg", Category = pc, Brand = samsung, Price = 2345 }
                );
                _context.SaveChanges();
            }
        }
    }
}
