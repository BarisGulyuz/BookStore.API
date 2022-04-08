using BookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities
{
    public class Role : BaseEntity
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
