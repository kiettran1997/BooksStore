using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BooksStore.Controllers;
using BooksStore.DTO;
using BooksStore.Filter;
using BooksStore.Repository;

namespace BooksStore.Data
{
    public class PublisherManager : IPublisherRepository
    {
        private readonly BooksStoreDbContext _context;
        private readonly IMapper _mapper;

        public PublisherManager(BooksStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Publisher AddPublisher(Models.Publisher publisher)
        {
            if (publisher == null)
            {
                throw new ArgumentNullException(nameof(publisher));
            }
            Publisher data = _mapper.Map<Publisher>(publisher);
            _context.Publishers.Add(data);
            _context.SaveChanges();

            return data;
        }

        public void DeletePublisher(Publisher publisher)
        {
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
        }

        public Publisher EditPublisher(Models.Publisher publisher)
        {
            var existingPublisher = _context.Authors.Find(publisher.Id);
            if (existingPublisher == null)
            {
                throw new ArgumentNullException(nameof(Publisher));
            }
            existingPublisher.Name = publisher.Name;
            Publisher data = _mapper.Map<Publisher>(existingPublisher);
            _context.Publishers.Update(data);
            _context.SaveChanges();
            return data;
        }

        public Publisher GetPublisherById(int id)
        {
            var data = _context.Publishers.Select(x => new Publisher()
            {
                Id = x.Id,
                Name = x.Name,
               

            });
            return data.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Publisher> GetPublishers(PaginationFilter filter = null)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var datas = _context.Publishers.Select(x => new Publisher()
            {
                Id = x.Id,
                Name = x.Name,
               
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
