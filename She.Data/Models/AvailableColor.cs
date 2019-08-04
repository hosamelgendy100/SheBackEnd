using She.Data.SharedKernel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace She.Data.Models
{
    public class AvailableColor: BaseEntity
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required")]
        [MaxLength(15, ErrorMessage = "The field {0} must be maximum {1} characters length")]
        public string Name { get; set; }
    }
}