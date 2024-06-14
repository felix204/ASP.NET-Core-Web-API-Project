using ECommerceAPI.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Entity.Poco
{
    public class Order : AuditableEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public virtual User User { get; set; }
        public int UserID { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
