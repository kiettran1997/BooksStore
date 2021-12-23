using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.DTO
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int AuthorId { get; set; }
       
        public int CategoryId { get; set; }

        public int PublisherId { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public Author Author { get; set; }
        
        public Publisher Publisher { get; set; }

        public Category Category { get; set; }
        //public virtual ICollection<BookInCategory> BookInCategorys { get; set; }

        public List<OderDetail> OrderDetails { get; set; }

    }
}
