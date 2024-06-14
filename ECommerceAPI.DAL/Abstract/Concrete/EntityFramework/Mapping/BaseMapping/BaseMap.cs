using ECommerceAPI.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.DAL.Abstract.Concrete.EntityFramework.Mapping.BaseMapping
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : AuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(q => q.ID);
            builder.Property(q => q.ID).ValueGeneratedOnAdd();
            builder.Property(q => q.Guid).ValueGeneratedOnAdd();
        }
    }
}
