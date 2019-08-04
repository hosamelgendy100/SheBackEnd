using System.ComponentModel.DataAnnotations;
using She.Data.SharedKernel;
using System;

namespace She.Data.Models
{
    public class ProductPhoto : BaseEntity
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required")]
        public string Url { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required")]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
        public bool IsMain { get; set; }

        public Product Product { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int ProductId { get; set; }
    }
}