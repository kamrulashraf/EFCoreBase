using Core.IRepository;
using Core.IValidation;
using Core.Model;
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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public CategoryRepository(IUnitOfWorkFactory unitOfWorkFactory, BaseDbContext contex, IGuardService gurdService) : base(gurdService)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            base.context = contex;
            base.dbSet = context.Set<Category>();

        }
        public int AddCategory(Category category)
        {
            base.Insert(category);
            var addedRowCount = base.SaveChanges();
            base._gurdService.AgainstDataUpdateSuccess(addedRowCount, HttpStatusCode.Conflict, "Unable to add category.");
            return addedRowCount;
        }

        public int DeleteCategory(long categoryID)
        {
            base.Delete(categoryID);
            var deletedRowCount = base.SaveChanges();
            base._gurdService.AgainstDataUpdateSuccess(deletedRowCount, HttpStatusCode.Conflict, "Unable to delete category.");
            return deletedRowCount;
        }

        public IEnumerable<Category> GetCategories()
        {
            return base.Query().ToList<Category>();
        }

        public Category GetCategory(long categoryID)
        {
            var category = base.Query(x => x.CategoryId == categoryID).FirstOrDefault();
            base._gurdService.AgainstNull(category, HttpStatusCode.NotFound, "No category available with this category ID.");
            return category;
        }

        public int UpdateCategory(Category category)
        {
            base.Update(category);
            var updatedRowCount = base.SaveChanges();
            base._gurdService.AgainstDataUpdateSuccess(updatedRowCount, HttpStatusCode.Conflict, "Unable to add category.");
            return updatedRowCount;
        }
    }
}
