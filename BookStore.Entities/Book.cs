using BookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities
{
    public class Book : BaseEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public int NumberofPages { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}
