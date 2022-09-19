using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IProductVariationService
    {
        public long AddProductVariation(ProductVariation variant);
        public long UpdateProductVariation(ProductVariation variant);
        public long DeleteProductVariation(long variantID);
        public ProductVariation GetProductVariation(long variantID);
        public IEnumerable<ProductVariation> GetProductsVariationList(long productID);

    }
}
