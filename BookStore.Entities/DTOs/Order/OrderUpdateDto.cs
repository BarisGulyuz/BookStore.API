using BookStore.Core.Entities.Abstract;

namespace BookStore.Entities.DTOs.Order
{
    public class OrderUpdateDto : UpdateDto
    {
        public int UserId { get; set; }
        public string City { get; set; }
        public string Adress { get; set; } 
        public string Note { get; set; }
        public int ShipmentStatus { get; set; }
    }
}
