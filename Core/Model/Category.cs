using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
