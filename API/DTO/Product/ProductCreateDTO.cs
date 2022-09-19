using API.DTO.Category;
using API.DTO.ProductVariation;

namespace API.DTO.Product
{
    public class ProductCreateDTO : ProductDTO
    {
        public CategoryCreateDTO? Category { get; set; }
        public ICollection<ProductVariationCreateDTO> ProductVariations { get; set; }

    }
}
