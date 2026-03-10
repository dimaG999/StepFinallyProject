using packstation.Enums;
using System.ComponentModel.DataAnnotations;

namespace packstation.Entities
{
    public class ParcelCategory
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        public ICollection<Parcel> Parcels=new List<Parcel>();
    }
}
