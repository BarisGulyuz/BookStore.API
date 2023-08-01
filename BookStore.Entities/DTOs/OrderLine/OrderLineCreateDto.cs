using BookStore.Core.Entities.Abstract;

namespace BookStore.Entities.DTOs.OrderLine
{
    public class OrderLineCreateDto : CreateDto
    {
        public string BookName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
    }
}
