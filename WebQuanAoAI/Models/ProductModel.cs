﻿using System.ComponentModel.DataAnnotations;

namespace WebQuanAoAI.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(1, ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        public string Name { get; set; }
        [Required, MinLength(1, ErrorMessage = "Vui lòng nhập mô tả sản phẩm")]
        public string Description { get; set; }
        public string Slug { get; set; }
        [Required, MinLength(1, ErrorMessage = "Vui lòng nhập giá sản phẩm")]
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public BrandModel Brand { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        public string Image { get; set; }
    }
}