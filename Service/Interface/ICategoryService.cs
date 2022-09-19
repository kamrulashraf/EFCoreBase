using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICategoryService
    {
        public int AddCategory(Category category);
        public int UpdateCategory(Category category);
        public int DeleteCategory(long categoryID);
        public IEnumerable<Category> GetAllCategories();
        public Category GetCategory(long categoryID);
    }
}
