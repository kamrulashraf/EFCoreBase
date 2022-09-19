using API.DTO.Product;

namespace API.DTO.Category
{
    public class CategoryViewDTO : CategoryDTO
    {
        public long CategoryId { get; set; }
        public ICollection<ProductDTO> Products { get; set; }
    }
}
