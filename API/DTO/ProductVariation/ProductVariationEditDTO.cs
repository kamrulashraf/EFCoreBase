namespace API.DTO.ProductVariation
{
    public class ProductVariationEditDTO : ProductVariationDTO
    {
        public int VariationId { get; set; }
        public long ProductID { get; set; }
    }
}
