using API.DTO.Product;
using System.ComponentModel.DataAnnotations;

namespace API.DTO.Category
{
    public class CategoryDTO : BaseDTO
    {
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
    }
}
