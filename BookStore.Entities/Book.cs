using BookStore.Core.Entities;
using System.Collections.Generic;

namespace BookStore.Entities
{
    public class Book : BaseEntity
    {
        public Book()
        {
            OrderLines = new HashSet<OrderLine>();
        }
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
        public int TotalQuantity { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
