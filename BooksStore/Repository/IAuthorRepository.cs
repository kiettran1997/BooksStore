using BooksStore.DTO;
using BooksStore.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Repository
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAuthors(PaginationFilter filter = null);

        Author GetAuthorById(int id);
        Author AddAuthor(Models.Author author);
        Author EditAuthor(Models.Author author);
        void DeleteAuthor(Author author);

        bool SaveChanges();
    }
}
