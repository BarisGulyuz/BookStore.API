using BookStore.Core.Entities;
using System.Collections.Generic;

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
