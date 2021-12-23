using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksStore.DTO;
using BooksStore.Filter;

namespace BooksStore.Repository
{
    public interface IPublisherRepository
    {
        IEnumerable<Publisher> GetPublishers(PaginationFilter filter = null);
        Publisher GetPublisherById(int id);
        Publisher AddPublisher(Models.Publisher publisher);
        Publisher EditPublisher(Models.Publisher publisher);
        void DeletePublisher(Publisher publisher);

        bool SaveChanges();
    }
}
