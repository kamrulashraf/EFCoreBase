using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IProductVariationRepository : IRepository<ProductVariation>
    {
        public IEnumerable<ProductVariation> GetAllProductsVariant(long ProductId);
        public ProductVariation GetProductVariation(long variantID);
        public long AddProductVariant(ProductVariation variant);
        public long UpdateProductVariant(ProductVariation variant);
        public int DeleteProductVariant(long productVariationId);
    }
}
