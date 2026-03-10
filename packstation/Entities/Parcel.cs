
using packstation.Enums;
using System.ComponentModel.DataAnnotations;

namespace packstation.Entities
{
    public class Parcel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Sending number is required")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Sending number must be exactly 5 digits ")]
        public string SendingNumber { get; set; }

        [Required(ErrorMessage = "Destination address is required")]
        [MaxLength(50, ErrorMessage = "Destination address cannot exceed 50 characters")]
        public string DestinationAddress { get; set; }

        [Required(ErrorMessage = "Parcel category is required")]
        public int? ParcelCategoryId { get; set; }
        public ParcelCategory ParcelCategory { get; set; }

        [Required(ErrorMessage = "User is required")]
        public int? UserId { get; set; } 
        public User User { get; set; }

        public ParcelStatus ParcelStatus { get; set; }
    }

}   


