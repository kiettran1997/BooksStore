using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.DTO
{
    public class Publisher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Book> Books { get; set; }

    }
}
