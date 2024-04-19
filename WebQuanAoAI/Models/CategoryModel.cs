using System.ComponentModel.DataAnnotations;

namespace WebQuanAoAI.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(1, ErrorMessage = "Vui lòng nhập tên danh mục")]
        public string Name { get; set; }
        [Required, MinLength(1, ErrorMessage = "Vui lòng nhập mô tả danh mục")]
        public string Description { get; set; }
        public string Slug { get; set; }
        public int Status { get; set; }
    }
}
