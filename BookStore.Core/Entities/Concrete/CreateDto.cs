using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Entities.Abstract
{
    public class CreateDto : IDto
    {
        public bool Status { get; set; }
    }
}
