using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.DAL.Abstract.Concrete.EntityFramework.Context
{
    public class ShopContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString: "datasource=.; inital catalog=Shopping233DB; integrated security=True; TrustServerCertificate=true");
            }
            base.OnConfiguring(optionsBuilder);
        }

    }
}
