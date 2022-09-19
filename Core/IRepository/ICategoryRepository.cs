using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public int AddCategory(Category category);
        public int UpdateCategory(Category category);
        public int DeleteCategory(long categoryID);
        public IEnumerable<Category> GetCategories();
        public Category GetCategory(long categoryID);
    }
}
