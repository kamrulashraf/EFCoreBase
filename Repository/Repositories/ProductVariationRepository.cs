using Core.AppExceptions;
using Core.IRepository;
using Core.IValidation;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductVariationRepository : GenericRepository<ProductVariation>, IProductVariationRepository
    {
        public readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ProductVariationRepository(IUnitOfWorkFactory unitOfWorkFactory, BaseDbContext contex, IGuardService nullGuard) : base(nullGuard)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            base.context = contex;
            base.dbSet = context.Set<ProductVariation>();
        }
        public long AddProductVariant(ProductVariation variant)
        {
            base.Insert(variant);
            var insertedRowCount = base.SaveChanges();
            base._gurdService.AgainstDataUpdateSuccess(insertedRowCount, HttpStatusCode.Conflict, "Unable to add Product variant.");
            return insertedRowCount;
        }

        public int DeleteProductVariant(long productVariationId)
        {
            base.Delete(Convert.ToInt32(productVariationId));
            var deletedRowCount = base.SaveChanges();
            base._gurdService.AgainstDataUpdateSuccess(deletedRowCount, HttpStatusCode.Conflict, "Unable to delete product variant.");
            return deletedRowCount;
        }

        public IEnumerable<ProductVariation> GetAllProductsVariant(long ProductId)
        {
            return base.Query(x => x.ProductID == ProductId).ToList<ProductVariation>();
        }

        public ProductVariation GetProductVariation(long variantID)
        {
            var variant =  base.Query(x => x.VariationId == variantID).Include(x => x.Discounts).FirstOrDefault();
            base._gurdService.AgainstNull(variant, HttpStatusCode.NotFound, "No Product variant Found.");
            return variant;
        }

        public long UpdateProductVariant(ProductVariation variant)
        {
            base.Update(variant);
            var updatedRowCount = base.SaveChanges();
            base._gurdService.AgainstDataUpdateSuccess(updatedRowCount, HttpStatusCode.Conflict, "Unable to update Product Variant.");
            return updatedRowCount;
        }
    }
}
