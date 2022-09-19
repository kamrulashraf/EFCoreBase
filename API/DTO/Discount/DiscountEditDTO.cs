namespace API.DTO.Discount
{
    public class DiscountEditDTO : DiscountDTO
    {
        public long DiscountId { get; set; }
        public long VariationId { get; set; }

    }
}
