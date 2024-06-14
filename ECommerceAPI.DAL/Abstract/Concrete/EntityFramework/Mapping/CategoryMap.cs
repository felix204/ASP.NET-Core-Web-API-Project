using ECommerceAPI.DAL.Abstract.Concrete.EntityFramework.Mapping.BaseMapping;
using ECommerceAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.DAL.Abstract.Concrete.EntityFramework.Mapping
{
    public class CategoryMap : BaseMap<Category>
    {
        public override void ConfigureCO(EntityTypeBuilder<Category> builder)
        {
            builder.Property(q => q.Name).HasMaxLength(500).IsRequired();
        }
    }
}
