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
    public class EfUSerRepository : AppRepository<User>, IUserRepository
    {
        public EfUSerRepository(BookStoreContext bookStoreContext) : base(bookStoreContext)
        {

        }
    }
}
