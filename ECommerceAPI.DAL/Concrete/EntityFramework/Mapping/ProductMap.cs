using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using ECommerceAPI.DAL.Concrete.EntityFramework.Mapping.BaseMapping;

namespace ECommerceAPI.DAL.Concrete.EntityFramework.Mapping
{
    public class ProductMap : BaseMap<Product>
    {

        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(q => q.Name).HasMaxLength(400).IsRequired();
            builder.HasOne(q => q.Category).WithMany(q => q.Products).HasForeignKey(q => q.CategoryID).OnDelete(DeleteBehavior.Cascade);
        }

    }
}
