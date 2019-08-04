using System.ComponentModel.DataAnnotations;
using She.Data.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace She.Data.Models
{
    public class Seller: BaseEntity
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} must be maximum {1} characters length")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required")]
        [MaxLength(30, ErrorMessage = "The field {0} must be maximum {1} characters length")]

        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required")]
        [MaxLength(30, ErrorMessage = "The field {0} must be maximum {1} characters length")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required")]
        [MaxLength(30, ErrorMessage = "The field {0} must be maximum {1} characters length")]
        public string CountryOfOrigin { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The field {0} must be maximum {1} characters length")]
        public string WebSiteUrl { get; set; }

    }
}
