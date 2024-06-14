using ECommerceAPI.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Entity.Poco
{
    public class Product : AuditableEntity
    {
        public Product()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }

        public virtual IEnumerable<OrderDetail>OrderDetails { get; set; }

        public virtual Category Category { get; set; }
    }
}
