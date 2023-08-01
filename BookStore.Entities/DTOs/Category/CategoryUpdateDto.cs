using BookStore.Core.Entities.Abstract;

namespace BookStore.Entities.DTOs.Category
{
    public class CategoryUpdateDto : UpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
