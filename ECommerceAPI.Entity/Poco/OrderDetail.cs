using ECommerceAPI.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Entity.Poco
{
    public class OrderDetail : AuditableEntity
    {
        public int OrderId { get; set; }
        public int ProductID { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public double? Discount { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }

}
