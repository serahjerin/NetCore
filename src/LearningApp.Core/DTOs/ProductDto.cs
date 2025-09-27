using System;
using System.ComponentModel.DataAnnotations;

namespace LearningApp.Core.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(1000)]
        public string? Description { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        
        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
        
        public string? ImageUrl { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        
        public string? CategoryName { get; set; }
        public string? UserName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}