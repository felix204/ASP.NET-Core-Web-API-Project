using ECommerceAPI.DAL.Concrete.EntityFramework.Mapping.BaseMapping;
using ECommerceAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.DAL.Concrete.EntityFramework.Mapping
{
    public class OrderMap : BaseMap<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasOne(q => q.User).WithMany(q => q.Orders).HasForeignKey(q => q.UserID).OnDelete(DeleteBehavior.Cascade);
            //builder.HasMany(q=>q.OrderDetails).WithOne(q=>q.Order).HasForeignKey(q=>q.OrderId).OnDelete(DeleteBehavior.Cascade);//OrderDetailMap de eğer ilişkilendirmeyi yazmasaydım bu kod bloğunuun çalışması gerekliydi.
        }
    }
}
