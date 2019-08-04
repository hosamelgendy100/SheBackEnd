using She.Data.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations;

namespace She.Data.Models
{
    public class User: BaseEntity
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field{0} must be maximum {1} characters length")]
        public string Name { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required")]
        [MaxLength(8, ErrorMessage = "The field {0} must be maximum {1} characters length")]
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? LastActive { get; set; }

        public UserRole Role { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int? UserRoleId { get; set; }
    }
}