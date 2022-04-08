using BookStore.Core.Entities.Abstract;
using BookStore.Entities.DTOs.OrderLine;
using BookStore.Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.DTOs.Order
{
    public class OrderGetDto : IDto
    {
        public int Id { get; set; }
        public UserGetDto User { get; set; }
        public List<OrderLineGetDto> OrderLines { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Note { get; set; }
        public int ShipmentStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Status { get; set; }
    }
}
