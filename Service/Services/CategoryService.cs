using Core.IRepository;
using Core.Model;
using Service.Interface;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public int AddCategory(Category category)
        {
            return _categoryRepo.AddCategory(category);
        }

        public int DeleteCategory(long categoryID)
        {
            return _categoryRepo.DeleteCategory(categoryID);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepo.GetCategories();
        }

        public Category GetCategory(long categoryID)
        {
            return _categoryRepo.GetCategory(categoryID);
        }

        public int UpdateCategory(Category category)
        {
            return _categoryRepo.UpdateCategory(category);
        }
    }
}
