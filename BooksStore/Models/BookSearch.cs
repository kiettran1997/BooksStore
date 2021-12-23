using BooksStore.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Models
{
    public class BookSearch 
    {
        public int? Id { get; set; }

        public string Name { get; set; }
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }
        
        


    }
}
