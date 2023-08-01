using BookStore.Core.Entities;
using System.Collections.Generic;

namespace BookStore.Entities
{
    public class Author : BaseEntity
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
