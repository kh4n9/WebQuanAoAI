using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebQuanAoAI.Repository.Validation;

namespace WebQuanAoAI.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Slug { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int BrandId { get; set; }
        public BrandModel Brand { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        public string Image { get; set; }
        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }
    }
}
