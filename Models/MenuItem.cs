using System;
using System.ComponentModel.DataAnnotations;

namespace GreatChef.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 1000.00, ErrorMessage = "Price must be between $0.01 and $1000.00")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Image URL is required")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required")]
        [StringLength(50, ErrorMessage = "Category cannot be longer than 50 characters")]
        public string Category { get; set; } = string.Empty;

        public bool IsAvailable { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
} 