using BookStore.Core.Entities.Abstract;

namespace BookStore.Entities.DTOs.Author
{
    public class AuthorCreateDto : CreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
    }
}
