using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Results
{
    public class CustomValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
