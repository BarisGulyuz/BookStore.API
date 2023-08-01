using BookStore.Core.Entities.Abstract;

namespace BookStore.Entities.DTOs.Author
{
    public class AuthorUpdateDto : UpdateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
    }
}
