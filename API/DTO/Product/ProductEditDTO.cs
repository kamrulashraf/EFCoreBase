using API.DTO.ProductVariation;

namespace API.DTO.Product
{
    public class ProductEditDTO : ProductDTO
    {
        public long ProductID { get; set; }
        public ICollection<ProductVariationEditDTO> ProductVariations { get; set; }
    }
}
