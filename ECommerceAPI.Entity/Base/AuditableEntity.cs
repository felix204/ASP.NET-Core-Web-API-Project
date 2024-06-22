using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Entity.Base
{
    public class AuditableEntity:BaseEntity
    {
        public DateTime? AddedTime { get; set; }
        public int? AddedUser { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public string? AddedIPv4Adress { get; set; }
        public string? UpdatedIPv4Adress { get; set; }
    }
}
