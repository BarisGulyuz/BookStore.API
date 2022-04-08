using BookStore.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Entities.Abstract
{
    public class UpdateDto : IDto
    {
          public int Id { get; set; }
          public bool Status { get; set; }
    }
}
