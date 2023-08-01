using BookStore.Core.Entities;
using System.Collections.Generic;

namespace BookStore.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
