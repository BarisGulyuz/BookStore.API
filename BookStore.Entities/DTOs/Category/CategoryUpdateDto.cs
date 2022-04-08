using BookStore.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Entities.DTOs.Category
{
    public class CategoryUpdateDto : UpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
       
    }
}
