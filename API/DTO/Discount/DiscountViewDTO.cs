using API.DTO.ProductVariation;

namespace API.DTO.Discount
{
    public class DiscountViewDTO : DiscountDTO
    {
        public long DiscountId { get; set; }
        public long VariationId { get; set; }
        public ProductVariationDTO ProductVeriation { get; set; }
    }
}
