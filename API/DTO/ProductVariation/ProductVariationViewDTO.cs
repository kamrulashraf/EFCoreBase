using API.DTO.Discount;
using API.DTO.Product;

namespace API.DTO.ProductVariation
{
    public class ProductVariationViewDTO : ProductVariationDTO
    {
        public int VariationId { get; set; }
        public long ProductID { get; set; }
        public ProductViewDTO Product { get; set; }
        public ICollection<DiscountViewDTO> Discounts { get; set; }
    }
}
