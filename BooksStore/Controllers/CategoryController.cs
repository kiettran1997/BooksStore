using BooksStore.Models;
using BooksStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksStore.Data;
using BooksStore.Wrappers;
using BooksStore.Filter;
using BooksStore.Helpers;

namespace BooksStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;



        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }
        //Get api/categorys
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAll([FromQuery] PaginationFilter filter)
        {
          
            var categoryItems = _repository.GetCategorys(filter);

            List<Category> datas = categoryItems.Select(x => new Category()
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Description = x.Description,
            }).ToList();



            return Ok(new PagedResponse<List<Category>>(datas, filter.PageNumber, filter.PageSize));
        }

        //Get api/category/{id}
        [HttpGet("{Id}")]
        public ActionResult<IEnumerable<Category>> GetId(int id)
        {
            var categoryItem = _repository.GetCategoryById(id);
            if (categoryItem == null)
                return NotFound();
            var data = new Category
            {
                Id = categoryItem.Id,
                Name = categoryItem.Name,
                Image = categoryItem.Image,
                Description = categoryItem.Description
            };


            return Ok(new Response<Category>(data));
        }

        [HttpPost]
        public ActionResult<IEnumerable<Category>> Create(Category category)
        {
            _repository.AddCategory(category);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + category.Id, new Response<Category>(category));
        }

        [HttpPatch("{id}")]
        public ActionResult<IEnumerable<Author>> Update(int id, Category category)
        {
            var existingCategory = _repository.GetCategoryById(id);
            if (existingCategory != null)
            {
                category.Id = existingCategory.Id;
                _repository.EditCategory(category);
            }
            return Ok(new Response<Category>(category));

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _repository.GetCategoryById(id);
            if (category != null)
            {
                _repository.DeleteCategory(category);
                return Ok();
            }
            return NotFound($"Book with Id: {id} was not found");
        }
    }
}