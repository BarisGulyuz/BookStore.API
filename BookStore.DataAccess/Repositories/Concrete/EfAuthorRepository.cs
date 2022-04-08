using BookStore.Core.DataAccess.Concrete;
using BookStore.DataAccess.Contexts;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Concrete
{
    public class EfAuthorRepository : AppRepository<Author>, IAuthorRepository
    {
        public EfAuthorRepository(BookStoreContext bookStoreContext) : base(bookStoreContext)
        {

        }
    }
}
