using ECommerceAPI.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Entity.Poco
{
    public class Category : AuditableEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        
        public string Name { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}
