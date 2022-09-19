using Core.AppExceptions;
using Core.IRepository;
using Core.IValidation;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.UnitOfWork;
using System.Net;

namespace Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ProductRepository(IUnitOfWorkFactory unitOfWorkFactory, BaseDbContext contex, IGuardService gurdService) : base(gurdService)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            base.context = contex;
            base.dbSet = context.Set<Product>();
            
        }

        public int AddProduct(Product product)
        {
            base.Insert(product);
            return base.SaveChanges();
        }

        public long AddProductVariant(ProductVariation variant)
        {
            var unitOfWork = _unitOfWorkFactory.Create();
            var variationUnit = unitOfWork.GetRepository<ProductVariation>();
            variationUnit.Insert(variant);
            var updatedRow = unitOfWork.SaveChanges();
            base._gurdService.AgainstDataUpdateSuccess(updatedRow, HttpStatusCode.Conflict, "Uable to add Product.");
            return updatedRow;

        }

        public int DeleteProduct(long productID)
        {
            base.Delete(productID);
            return base.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var query = base.Query().Include(x => x.Category).Include(x => x.ProductVariations).ThenInclude(x => x.Discounts).AsSingleQuery();
            return query.ToList<Product>();
        }

        public Product? GetProduct(long productID)
        {
            var temp =  base.Query(x => x.ProductID == productID).Include(x => x.Category).Include(x => x.ProductVariations).ThenInclude(x => x.Discounts).FirstOrDefault();
            return temp;
        }

        public int UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
