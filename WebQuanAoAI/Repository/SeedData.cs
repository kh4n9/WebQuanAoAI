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
                CategoryModel laptop = new CategoryModel { Name = "Laptop", Slug = "laptop", Description = "Laptop is Large Brand in the world", Status = 1 };
                CategoryModel pc = new CategoryModel { Name = "Pc", Slug = "pc", Description = "Pc is Large Brand in the world", Status = 1 };
                BrandModel apple = new BrandModel { Name = "Apple", Slug = "apple", Description = "Apple is Large Brand in the world", Status = 1 };
                BrandModel samsung = new BrandModel { Name = "Samsung", Slug = "samsung", Description = "Samsung is Large Brand in the world", Status = 1 };
                _context.Products.AddRange(
                    new ProductModel { Name = "macbook", Slug = "macbook", Description = "macbook is the best", Image = "1.jpeg", Category = laptop, Brand = apple, Price = 1234 },
                    new ProductModel { Name = "Pc Samsung", Slug = "pcsamsung", Description = "pcsamsung is the best", Image = "1.jpeg", Category = pc, Brand = samsung, Price = 2345 }
                );
                _context.SaveChanges();
            }
        }
    }
}
