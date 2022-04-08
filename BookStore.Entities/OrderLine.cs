using BookStore.Core.Entities;

namespace BookStore.Entities
{
    public class OrderLine : BaseEntity
    {
        public string BookName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}