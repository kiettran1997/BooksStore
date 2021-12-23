using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int quantity { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public Book Book { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

    }
}
