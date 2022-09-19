using Core.IRepository;
using Core.Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public int AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public long AddProductVariant(ProductVariation variant)
        {
            var variantID =  _productRepository.AddProductVariant(variant);
             return variantID;
        }

        public int DeleteProduct(long productID)
        {
            return _productRepository.DeleteProduct(productID);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public IEnumerable<Product> GetAllProductsByCategory()
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(long productID)
        {
            return _productRepository.GetProduct(productID);
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
