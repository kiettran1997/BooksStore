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
    public class AuthorManager : IAuthorRepository
    {
        private readonly BooksStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorManager(BooksStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public Author AddAuthor(Models.Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }
            Author data = _mapper.Map<Author>(author);
            _context.Authors.Add(data);
            _context.SaveChanges();

            return data;
        }

        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public Author EditAuthor(Models.Author author)
        {
            var existingAuthor = _context.Authors.Find(author.Id);
            if (existingAuthor == null)
            {
                throw new ArgumentNullException(nameof(author));
            }
            existingAuthor.Name = author.Name;
            Author data = _mapper.Map<Author>(existingAuthor);
            _context.Authors.Update(data);
            _context.SaveChanges();
            return data;
        }

        public Author GetAuthorById(int id)
        {
            var data = _context.Authors.Select(x => new Author()
            {
                Id = x.Id,
                Name = x.Name,
               

            });
            return data.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Author> GetAuthors(PaginationFilter filter = null)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var datas = _context.Authors.Select(x => new Author()
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
