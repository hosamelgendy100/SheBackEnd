using System.ComponentModel.DataAnnotations;
using She.Data.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace She.Data.Models
{  
    public class Product : BaseEntity
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} must be maximum {1} characters length")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required")]
        public string Description { get; set; }
        public string Color { get; set; }


        [Required(ErrorMessage = "The field {0} is required")]
        public double Price { get; set; }
        public int Count { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastEdit { get; set; }

        public bool OnSale { get; set; }
        public ICollection<ProductPhoto> ProductPhotos { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }

        public virtual Category Category { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public int CategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public int SubCategoryId { get; set; }

        // The user added the product
        public virtual User User { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public int UserId { get; set; }

        public virtual Seller Seller { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public int SellerId { get; set; }

    }
}
