using BooksStore.DTO;
using BooksStore.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Repository
{
    public interface IBookRepository
    {

        IEnumerable<Book> GetBooks(PaginationFilter filter = null);
        IEnumerable<Book> GetBook(PaginationFilter filter = null);
        Book GetBookById(int id);
        Book AddBook(Models.Book book);
        Book EditBook(Models.Book book);
        void DeleteBook(Book book);

        bool SaveChanges();
    }
}
