using BooksStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Services
{
    public abstract class UserDBBase
    {
        protected BooksStoreDbContext UserDBContext { get; }

        public UserDBBase(BooksStoreDbContext userDBContext)
        {
            UserDBContext = userDBContext ?? throw new System.ArgumentNullException(nameof(userDBContext));
        }
    }
}