using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAllProducts();
        public IEnumerable<Product> GetAllProductsByCategory();
        public Product GetProduct(long productID);
        public int AddProduct(Product product);
        public int DeleteProduct(long productID);
        public void UpdateProduct(Product product);
        public long AddProductVariant(ProductVariation variant);
    }
}
