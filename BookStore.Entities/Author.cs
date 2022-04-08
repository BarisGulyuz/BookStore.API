using BookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
