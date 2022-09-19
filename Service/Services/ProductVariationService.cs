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
    public class ProductVariationService : IProductVariationService
    {
        private readonly IProductVariationRepository _productVariationRepo;

        public ProductVariationService(IProductVariationRepository productVariationRepo)
        {
            _productVariationRepo = productVariationRepo;
        }

        public long AddProductVariation(ProductVariation variant)
        {
            return _productVariationRepo.AddProductVariant(variant);
        }

        public long DeleteProductVariation(long variantID)
        {
            return _productVariationRepo.DeleteProductVariant(variantID);
        }

        public IEnumerable<ProductVariation> GetProductsVariationList(long productID)
        {
            return _productVariationRepo.GetAllProductsVariant(productID);
        }

        public ProductVariation GetProductVariation(long variantID)
        {
            return _productVariationRepo.GetProductVariation(variantID);
        }

        public long UpdateProductVariation(ProductVariation variant)
        {
            return _productVariationRepo.UpdateProductVariant(variant);
        }
    }
}
