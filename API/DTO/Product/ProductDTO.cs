using System.ComponentModel.DataAnnotations;

namespace API.DTO.Product
{
    public class ProductDTO : BaseDTO
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        public long CategoryId { get; set; }
    }
}
