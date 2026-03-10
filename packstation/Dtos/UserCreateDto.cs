using packstation.Enums;
using System.ComponentModel.DataAnnotations;

namespace packstation.Dtos
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "User name is required")]
        [MaxLength(50, ErrorMessage = "User name cannot exceed 50 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User Lastname is required")]
        [MaxLength(50, ErrorMessage = "User name cannot exceed 50 characters")]
        public string UserLastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email {  get; set; }

        public string Password { get; set; }

        [Required]
        public UserRole Role { get; set; }
    }
}
