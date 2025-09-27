using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LearningApp.Core.Enums;

namespace LearningApp.Core.Entities
{
    public class Order : BaseEntity
    {
        [Required]
        public string OrderNumber { get; set; } = string.Empty;
        
        [Required]
        public string UserId { get; set; } = string.Empty;
        
        [Required]
        public DateTime OrderDate { get; set; }
        
        [Required]
        public OrderStatus Status { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal TotalAmount { get; set; }
        
        [MaxLength(500)]
        public string? Notes { get; set; }
        
        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}