using AutoMapper;
using BooksStore.Controllers;
using BooksStore.DTO;
using BooksStore.Filter;
using BooksStore.Repository;
using BooksStore.Wrappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Data
{
    public class BookManager : IBookRepository
    {

        private readonly BooksStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookManager(BooksStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      
        public Book EditBook(Models.Book book)
        {
            var existingBook = _context.Books.Find(book.Id);
            if (existingBook == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            existingBook.CategoryId = book.CategoryId;
            existingBook.Name = book.Name;
            existingBook.AuthorId = book.AuthorId;
            existingBook.PublisherId = book.PublisherId;
            Book data = _mapper.Map<Book>(existingBook);
            _context.Books.Update(data);
            _context.SaveChanges();
            return data;
        }

        public Book GetBookById(int id)
        {
            var query = from p in _context.Books
                        join c in _context.Categories on p.CategoryId equals c.Id into picc
                        from c in picc.DefaultIfEmpty()
                        join au in _context.Authors on p.AuthorId equals au.Id into aau
                        from au in aau.DefaultIfEmpty()
                        join pu in _context.Publishers on p.PublisherId equals pu.Id into ppu
                        from pu in ppu.DefaultIfEmpty()
                        select new { p, c, au, pu, };

            var data = query.Select(x => new Book()
            {
                Id = x.p.Id,
                Name = x.p.Name,
                Image = x.p.Image,
                Price = x.p.Price,
                Category = x.c,
                Description = x.p.Description,
                Author = x.au,
                Publisher = x.pu,
            });

            return data.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Book> GetBook(PaginationFilter filter = null)
        {
            var query = from p in _context.Books
                        
                        join c in _context.Categories on p.CategoryId equals c.Id into picc
                        from c in picc.DefaultIfEmpty()
                        join au in _context.Authors on p.AuthorId equals au.Id into aau
                        from au in aau.DefaultIfEmpty()
                        join pu in _context.Publishers on p.PublisherId equals pu.Id into ppu
                        from pu in ppu.DefaultIfEmpty()
                        select new { p, c,au, pu , };

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var data =  query.Select(x => new Book()
            {
                Id = x.p.Id,
                Name = x.p.Name,
                Image = x.p.Image,
                Price = x.p.Price,
                Category = x.c,
                Description = x.p.Description,
                Author = x.au,
                Publisher = x.pu,
            }).ToList();
            var pagedData = data.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
              .Take(validFilter.PageSize)
              .ToList();
            var totalRecords = data.Count();


            return pagedData;
        }

        public IEnumerable<Book> GetBooks( PaginationFilter filter = null)
        {
            if (string.IsNullOrEmpty(filter.Name)  && (filter.PriceFrom == null) && (filter.PriceTo == null))
                return GetBook(filter);

         

            var result = _context.Books as IQueryable<Book>;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            if (result != null)
            {
                if (filter.Id.HasValue)
                    result = result.Where(x => x.Id == filter.Id);
                if (!string.IsNullOrEmpty(filter.Name))
                    result = result.Where(x => x.Name.Contains(filter.Name));
                if (filter.PriceFrom.HasValue)
                    result = result.Where(x => x.Price >= filter.PriceFrom);
                if (filter.PriceTo.HasValue)
                    result = result.Where(x => x.Price <= filter.PriceTo);
            }

            var query = from p in result

                        join c in _context.Categories on p.CategoryId equals c.Id into picc
                        from c in picc.DefaultIfEmpty()
                        join au in _context.Authors on p.AuthorId equals au.Id into aau
                        from au in aau.DefaultIfEmpty()
                        join pu in _context.Publishers on p.PublisherId equals pu.Id into ppu
                        from pu in ppu.DefaultIfEmpty()
                        select new { p, c, au, pu, };
            var data = query.Select(x => new Book()
            {
                Id = x.p.Id,
                Name = x.p.Name,
                Image = x.p.Image,
                Price = x.p.Price,
                Category = x.c,
                Description = x.p.Description,
                Author = x.au,
                Publisher = x.pu,
            }).ToList();

            var pagedData = data.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
              .Take(validFilter.PageSize)
              .ToList();
            var totalRecords = result.Count();


            return pagedData;
        }

        public Book AddBook(Models.Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            Book data = _mapper.Map<Book>(book);
            _context.Books.Add(data);
            _context.SaveChanges();

            return data;
        }

        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();

        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }


       
    }

}
