using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.DTO
{
    public class Author
    {

        public int Id { get; set; }

        public string Name { get; set;}

        public ICollection<Book> Books { get; set; }

    }
}
