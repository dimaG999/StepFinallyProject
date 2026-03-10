using packstation.Enums;

namespace packstation.Dtos
{
    public class ParcelResponseDto
    {
        public int Id { get; set; }
        public string SendingNumber { get; set; }
        public string DestinationAddress { get; set; }
        public ParcelStatus ParcelStatus { get; set; }

        public int ParcelCategoryId { get; set; }
        

        public int UserId { get; set; }
        
        
      
      
    }
}
