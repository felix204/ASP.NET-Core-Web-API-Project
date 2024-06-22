using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Entity.Results
{
    public class ErrorInformation
    {
        public object? Error { get; set; }
        public string ErrorDescription { get; set; }
    }
}
