using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksStore.DTO;


namespace BooksStore.Repository
{
    public interface IOderRepository
    {
        IEnumerable<Oder> GetAll();
        Oder GetById(int id);

    }
}
