using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.DTO
{
    public class OderDetail
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int quantity { get; set; }

        public int OrderId { get; set; }

        public Oder Order { get; set; }

        public Book Book { get; set; }


    }
}
