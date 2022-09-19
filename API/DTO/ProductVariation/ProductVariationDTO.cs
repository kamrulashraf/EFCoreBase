using System.ComponentModel.DataAnnotations;

namespace API.DTO.ProductVariation
{
    public class ProductVariationDTO : BaseDTO
    {
        [Required]
        [MaxLength(30)]
        public string VariationType { get; set; }
        [Required]
        public double Price { get; set; }
        public string Image { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
