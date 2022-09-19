using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProduct(long ProductID);
        public IEnumerable<Product> GetAllProducts();
        public int AddProduct(Product product);
        public int UpdateProduct(Product product);
        public int DeleteProduct(long productID);
        public long AddProductVariant(ProductVariation variant);
    }
}
