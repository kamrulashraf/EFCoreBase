using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class Product
    {
        [Key]
        public long ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection <ProductVariation> ProductVariations { get; set; }
    }
}
