using System.Collections.Generic;

namespace BookStore.Entities.BasketEntities
{
    public class Basket
    {
        public Basket()
        {

        }
        public Basket(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}
