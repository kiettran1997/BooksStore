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
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;


        public BookController(IBookRepository repository )
        {
            _repository = repository;
        }

        //Get api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll([FromQuery] PaginationFilter  filter )
        {
            var item =  _repository. GetBooks(filter);
            List<Book> datas = item.Select(x => new Book()
            {
                Id = x.Id,
                AuthorId = x.AuthorId,
                PublisherId = x.PublisherId,
                CategoryId = x.CategoryId,
                Name = x.Name,
                Image = x.Image,
                Price = x.Price,
                Category = x.Category.Name,
                Description = x.Description,
                Author = x.Author.Name,
                Publisher = x.Publisher.Name,
            }).ToList();
           
            return Ok( new PagedResponse<List<Book>>(datas , filter.PageNumber, filter.PageSize));

        }


        //Get api/books/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Book>> GetById(int id)
        {
            var bookItem = _repository.GetBookById(id);
            if (bookItem == null) 
                return NotFound();
            var data = new Book
            {
                Id = bookItem.Id,
                Name = bookItem.Name,
                Image = bookItem.Image,
                Price = bookItem.Price,
                Category = bookItem.Category.Name,
                Description = bookItem.Description,
                Author = bookItem.Author.Name,
                Publisher = bookItem.Publisher.Name
            };

            return Ok(new Response<Book>(data));
        }

        [HttpPost]
        public ActionResult<IEnumerable<DTO.Book>> Create(Book book)
        {
            
            _repository.AddBook(book);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + book.Id, new Response<Book>(book));
        }

        [HttpPatch("{id}")]
        public ActionResult<IEnumerable<Book>> Update(int id, Book book)
        {
            var existingBook = _repository.GetBookById(id);
            if(existingBook != null)
            {
                book.Id = existingBook.Id;
                _repository.EditBook(book);
            }
            return Ok(new Response<Book>(book));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _repository.GetBookById(id);
            if(book != null)
            {
                _repository.DeleteBook(book);
                return Ok();
            }
            return NotFound($"Book with Id: {id} was not found");
        }
    }
}
