using She.Data.SharedKernel;
using System.ComponentModel.DataAnnotations;

namespace She.Data.Models
{
    public class UserRole : BaseEntity
    {
        [Required(AllowEmptyStrings =false, ErrorMessage = "The field {0} is required")]
        [MaxLength(20, ErrorMessage = "The field {0} must be maximum {1} characters length")]
        public string Name { get; set; }
    }
}