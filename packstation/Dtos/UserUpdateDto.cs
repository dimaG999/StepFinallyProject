using packstation.Enums;
using System.ComponentModel.DataAnnotations;

namespace packstation.Dtos
{
    public class UserUpdateDto
    {
        [Required(ErrorMessage = "User name is required")]
        [MaxLength(50, ErrorMessage = "User name cannot exceed 50 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User lastname is required")]
        [MaxLength(50, ErrorMessage = "User name cannot exceed 50 characters")]
        public string UserLastName { get; set; }
        [Required]
        public UserRole Role { get; set; }
    }
}
