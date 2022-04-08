using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.DTOs.Book
{
    public class BookCreateDto
    {
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public IFormFile Image { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public float Price { get; set; }
        public int NumberofPages { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
     
    }
}
