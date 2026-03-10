
using Microsoft.AspNetCore.Identity;
using packstation.Enums;
using System.ComponentModel.DataAnnotations;

namespace packstation.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User name is required")]
        [MaxLength(50, ErrorMessage = "User name cannot exceed 50 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "User last name is required")]
        [MaxLength(50, ErrorMessage = "User last name cannot exceed 50 characters")]
        public string UserLastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string PasswordHash { get; set; } = null!;
        public UserRole Role { get; set; }

        public ICollection<Parcel> SentParcels { get; set; }= new List<Parcel>();
        
    }


}

