using BookStore.Core.Entities.Abstract;
using System;

namespace BookStore.Entities.DTOs.Category
{
    public class CategoryGetDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Status { get; set; }
    
    }
}
