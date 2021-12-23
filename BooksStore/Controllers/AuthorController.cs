using BooksStore.Models;
using BooksStore.Data;
using BooksStore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksStore.Filter;
using BooksStore.Wrappers;
using BooksStore.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace BooksStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _repository;



        public AuthorController (IAuthorRepository repository)
        {
            _repository = repository;
        }


        //Get api/author
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAll([FromQuery] PaginationFilter filter)
        {
            var authorItems = _repository.GetAuthors(filter);

            List<Author> datas = authorItems.Select(x => new Author()
            {
                Id = x.Id,
                Name = x.Name,
                
            }).ToList();


            return Ok(new PagedResponse<List<Author>>(datas, filter.PageNumber, filter.PageSize));
        }

        //Get api/author/{id}
        [HttpGet("{Id}")]
        public ActionResult<IEnumerable<Author>> GetId(int id)
        {
            var authorItem = _repository.GetAuthorById(id);
            if (authorItem == null)
                return NotFound();
            var data = new Author
            {
                Id = authorItem.Id,
                Name = authorItem.Name
            };

            return Ok(new Response<Author>(data));
        }


        [HttpPost]
        public ActionResult<IEnumerable<Author>> Create(Author author)
        {
            _repository.AddAuthor(author);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + author.Id, new Response<Author>(author));
        }

        [HttpPatch("{id}")]
        public ActionResult<IEnumerable<Author>> Update(int id, Author author)
        {
            var existingAuthor = _repository.GetAuthorById(id);
            if (existingAuthor != null)
            {
                author.Id = existingAuthor.Id;
                _repository.EditAuthor(author);
            }
            return Ok(new Response<Author>(author));

        }


        [HttpDelete("{id}")]
        public IActionResult Deleter(int id)
        {
            var author = _repository.GetAuthorById(id);
            if (author != null)
            {
                _repository.DeleteAuthor(author);
                return Ok();
            }
            return NotFound($"Book with Id: {id} was not found");
        }
    }
}
