using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }

        public DateTime AddDate { get; set; }

        public string Note { get; set; }

        public Customer Customer { get; set; }

    }
}
