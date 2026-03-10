using packstation.Enums;
using System.ComponentModel.DataAnnotations;

namespace packstation.Dtos
{
    public class ParcelUpdateDto
    {
        [Required(ErrorMessage = "Sending number is required")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Sending number must be exactly 5 digits ")]
        public string SendingNumber { get; set; }

        [Required(ErrorMessage = "Parcel category is required")]
        public int ParcelCategoryId { get; set; }

        [Required(ErrorMessage = "Destination address is required")]
        [MaxLength(50, ErrorMessage = "Destination address cannot exceed 50 characters")]
        public string DestinationAddress { get; set; }
        public int UserId { get; set; }
       
        public ParcelStatus ParcelStatus { get; set; }
    }
}
