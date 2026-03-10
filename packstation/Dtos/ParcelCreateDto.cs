using packstation.Enums;
using System.ComponentModel.DataAnnotations;

namespace packstation.Dtos
{
    public class ParcelCreateDto
    {

        [Required(ErrorMessage = "Sending number is required")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Sending number must be exactly 5 digits ")]
        public string SendingNumber { get; set; }

        [Required(ErrorMessage = "User last name is required")]
        [MaxLength(50, ErrorMessage = "User last name cannot exceed 50 characters")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Destination address is required")]
        [MaxLength(50, ErrorMessage = "Destination address cannot exceed 50 characters")]
        public string DestinationAddress { get; set; }
        public int ParcelCategoryId { get; set; }

    }
}
