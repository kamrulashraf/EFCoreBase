using API.DTO.Category;
using API.DTO.ProductVariation;

namespace API.DTO.Product
{
    public class ProductViewDTO : ProductDTO
    {
        public long ProductID { get; set; }
        public CategoryDTO Category { get; set; }
        public ICollection<ProductVariationViewDTO> ProductVariations { get; set; }
    }
}
