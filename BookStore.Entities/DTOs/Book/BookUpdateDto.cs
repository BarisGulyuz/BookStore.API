using BookStore.Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace BookStore.Entities.DTOs.Book
{
    public class BookUpdateDto : UpdateDto
    {
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public IFormFile NewImage { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public float Price { get; set; }
        public int NumberofPages { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public int TotalQuantity { get; set; }
    }
}
