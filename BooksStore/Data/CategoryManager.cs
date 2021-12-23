using AutoMapper;
using BooksStore.Controllers;
using BooksStore.DTO;
using BooksStore.Filter;
using BooksStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Data
{
    public class CategoryManager : ICategoryRepository
    {
        private readonly BooksStoreDbContext _context;
        private readonly IMapper _mapper;

        public CategoryManager(BooksStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Category AddCategory(Models.Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            Category data = _mapper.Map<Category>(category);
            _context.Categories.Add(data);
            _context.SaveChanges();

            return data;
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public Category EditCategory(Models.Category category)
        {
            var existingcategory = _context.Categories.Find(category.Id);
            if (existingcategory == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            existingcategory.Name = category.Name;
            Category data = _mapper.Map<Category>(existingcategory);
            _context.Categories.Update(data);
            _context.SaveChanges();
            return data;
        }

        public Category GetCategoryById(int id)
        {
            var data = _context.Categories.Select(x => new Category()
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Description = x.Description,

            });
            return data.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Category> GetCategorys(PaginationFilter filter = null)
        {

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var datas = _context.Categories.Select(x => new Category()
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Description = x.Description,
               
            }).ToList();
            var pagedData = datas.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
             .Take(validFilter.PageSize)
             .ToList();
            var totalRecords = datas.Count();


            return pagedData;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
