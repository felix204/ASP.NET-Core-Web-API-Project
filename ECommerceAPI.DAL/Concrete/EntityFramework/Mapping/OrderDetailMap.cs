using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerceAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.DAL.Concrete.EntityFramework.Mapping.BaseMapping;

namespace ECommerceAPI.DAL.Concrete.EntityFramework.Mapping
{
    public class OrderDetailMap : BaseMap<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail");
            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(q => q.Product).WithMany(q => q.OrderDetails).HasForeignKey(q => q.ProductID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
