using ECommerceAPI.DAL.Abstract.Concrete.EntityFramework.Mapping.BaseMapping;
using ECommerceAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.DAL.Abstract.Concrete.EntityFramework.Mapping
{
    public class UserMap:BaseMap<User>
    {

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            //builder.HasMany(q=>q.Orders).WithOne(q=> q.User).HasForeignKey(q=>q.UserID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }

    }
}
