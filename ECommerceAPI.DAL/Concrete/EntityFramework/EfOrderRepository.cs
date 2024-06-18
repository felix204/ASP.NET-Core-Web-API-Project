using ECommerceAPI.DAL.Abstract;
using ECommerceAPI.DAL.Abstract.DataManagment;
using ECommerceAPI.DAL.Concrete.EntityFramework.DataManagment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.DAL.Concrete.EntityFramework
{
    public class EfOrderRepository : EfRepository<Order>, IOrderRepository
    {
        public EfOrderRepository(DbContext context) : base(context)
        {
        }
    }
}
