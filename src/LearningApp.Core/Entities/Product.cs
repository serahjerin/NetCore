using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningApp.Core.Entities
{
    public class Product : BaseEntity
    {
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
        
        [Required]
        public string UserId { get; set; } = string.Empty;
        
        // Navigation properties
        public virtual Category Category { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}