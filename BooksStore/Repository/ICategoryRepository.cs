using BooksStore.DTO;
using BooksStore.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategorys(PaginationFilter filter = null);
        Category GetCategoryById(int id);
        Category AddCategory(Models.Category category);
        Category EditCategory(Models.Category category);
        void DeleteCategory(Category category);

        bool SaveChanges();
    }
}
