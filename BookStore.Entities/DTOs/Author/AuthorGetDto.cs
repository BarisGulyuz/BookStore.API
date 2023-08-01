using BookStore.Core.Entities.Abstract;
using System;

namespace BookStore.Entities.DTOs.Author
{
    public class AuthorGetDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
