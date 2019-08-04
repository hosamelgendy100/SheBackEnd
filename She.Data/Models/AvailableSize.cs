using System.ComponentModel.DataAnnotations;
using She.Data.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace She.Data.Models
{
    public class AvailableSize : BaseEntity
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required")]
        [MaxLength(10, ErrorMessage = "The field {0} must be maximum {1} characters length")]
        public string Name { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }

    }
}
