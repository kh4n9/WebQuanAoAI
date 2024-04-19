using System.ComponentModel.DataAnnotations;

namespace WebQuanAoAI.Models
{
    public class BrandModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(1, ErrorMessage = "Vui lòng nhập tên thương hiệu")]
        public string Name { get; set; }
        [Required, MinLength(1, ErrorMessage = "Vui lòng nhập mô tả thương hiệu")]
        public string Description { get; set; }
        public string Slug { get; set; }
        public int Status { get; set; }
    }
}
