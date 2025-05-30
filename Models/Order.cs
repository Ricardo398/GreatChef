using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GreatChef.Repositories;

namespace GreatChef.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        [StringLength(100, ErrorMessage = "Customer name cannot be longer than 100 characters")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Customer email is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string CustomerEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Customer phone is required")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string CustomerPhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required")]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [Required(ErrorMessage = "Total amount is required")]
        [Range(0.01, 10000.00, ErrorMessage = "Total amount must be between $0.01 and $10000.00")]
        public decimal TotalAmount { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } = null!;

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Unit price is required")]
        [Range(0.01, 1000.00, ErrorMessage = "Unit price must be between $0.01 and $1000.00")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Subtotal is required")]
        [Range(0.01, 100000.00, ErrorMessage = "Subtotal must be between $0.01 and $100000.00")]
        public decimal Subtotal { get; set; }
    }
} 