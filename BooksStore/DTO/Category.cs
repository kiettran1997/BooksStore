using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.DTO
{
    public class Category
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        //public virtual ICollection<BookInCategory> BookInCategorys { get; set; }
        public List<Book> Books { get; set; }

    }
}
