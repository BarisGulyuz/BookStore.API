using BookStore.Core.Entities.Abstract;

namespace BookStore.Entities.DTOs.Order
{
    public class OrderCreateDto : CreateDto
    {
        public string City { get; set; }
        public string Adress { get; set; }
        public string Note { get; set; }
    }
}
