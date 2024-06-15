using ECommerceAPI.DAL.Abstract.Concrete.EntityFramework.Mapping.BaseMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.DAL.Abstract.Concrete.EntityFramework.Mapping
{
    public class ProductMap:BaseMap<Product>
    {

        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(q => q.Name).HasMaxLength(400).IsRequired();
            builder.HasOne(q=>q.Category).WithMany(q=>q.Products).HasForeignKey(q=>q.CategoryID).OnDelete(DeleteBehavior.Cascade);
        }

    }
}
