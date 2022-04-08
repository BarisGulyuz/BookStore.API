using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
