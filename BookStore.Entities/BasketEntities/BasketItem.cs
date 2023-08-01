namespace BookStore.Entities.BasketEntities
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
