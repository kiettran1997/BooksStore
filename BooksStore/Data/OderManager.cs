using BooksStore.DTO;
using BooksStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Data
{
    public class OderManager : IOderRepository
    {
        private readonly BooksStoreDbContext _context;

        public OderManager(BooksStoreDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Oder> GetAll()
        {

            return _context.Orders;
        }

        public Oder GetById(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == id);
        }
    }
}
