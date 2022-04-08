using BookStore.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.DTOs.Order
{
    public class OrderCreateDto : CreateDto
    {
        //public int UserId { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Note { get; set; }
        //public int ShipmentStatus { get; set; }
    }
}
