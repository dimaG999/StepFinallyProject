using packstation.Entities;
using System.ComponentModel.DataAnnotations;

namespace packstation.Dtos
{
    public class CategoryUpdateDto
    {
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        public int ParcelCategoryId { get; set; }
        
    }
}
