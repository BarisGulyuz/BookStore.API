using BookStore.Entities.DTOs.Author;
using BookStore.Entities.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.DTOs.Book
{
   public class BookGetDto
    {
        public int Id { get; set; }
        public CategoryGetDto Category { get; set; }
        public AuthorGetDto Author { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public float Price { get; set; }
        public int NumberofPages { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Status { get; set; }
    }
}
