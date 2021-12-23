using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.DTO
{
    public class BookInCategory
    {
        public int Id { get; set; }
        public int BookId { get; set; }
       //public Book Book { get; set; }
        public int CategoryId { get; set; }
        //public Category Category { get; set; }
    }
}
