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

namespace BooksStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _repository;


        public PublisherController(IPublisherRepository repository)
        {
            _repository = repository;
        }

        //Get api/author
        [HttpGet]
        public ActionResult<IEnumerable<Publisher>> GetAll([FromQuery] PaginationFilter filter)
        {
            var publisherItems = _repository.GetPublishers(filter);

            List<Publisher> datas = publisherItems.Select(x => new Publisher()
            {
                Id = x.Id,
                Name = x.Name,

            }).ToList();
            return Ok(new PagedResponse<List<Publisher>>(datas, filter.PageNumber, filter.PageSize));

        }

        //Get api/author/{id}
        [HttpGet("{Id}")]
        public ActionResult<IEnumerable<Publisher>> GetById(int id)
        {
            var publisherItem = _repository.GetPublisherById(id);
            if (publisherItem == null)
                return NotFound();
            var data = new Publisher
            {
                Id = publisherItem.Id,
                Name = publisherItem.Name
            };


            return Ok(new Response<Publisher>(data));
        }

        [HttpPost]
        public ActionResult<IEnumerable<Publisher>> Create(Publisher publisher)
        {
            _repository.AddPublisher(publisher);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + publisher.Id, new Response<Publisher>(publisher));
        }

        [HttpPatch("{id}")]
        public ActionResult<IEnumerable<Author>> Update(int id, Publisher  publisher)
        {
            var existingPublisher = _repository.GetPublisherById(id);
            if (existingPublisher != null)
            {
                publisher.Id = existingPublisher.Id;
                _repository.EditPublisher(publisher);
            }
            return Ok(new Response<Publisher>(publisher));

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = _repository.GetPublisherById(id);
            if (publisher != null)
            {
                _repository.DeletePublisher(publisher);
                return Ok();
            }
            return NotFound($"Book with Id: {id} was not found");
        }
    }
}
