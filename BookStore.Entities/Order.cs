using BookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
        }
        public int UserId { get; set; }
        public User User { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }  //can be built as a table associated with the user
        public string Note { get; set; }
        public int ShipmentStatus { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
