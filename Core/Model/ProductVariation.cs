using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class ProductVariation
    {
        [Key]
        public int VariationId { get; set; }
        [Required]
        [MaxLength(30)]
        public string VariationType { get; set; }
        [Required]
        public double Price { get; set; }
        public string Image { get; set; }
        [Required]
        public int Quantity { get; set; }
        public long ProductID { get; set; }
        public Product Product { get; set; }
        public ICollection<Discount> Discounts { get; set; }
    }
}
