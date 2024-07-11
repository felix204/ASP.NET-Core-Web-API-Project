using ECommerceAPI.DAL.Abstract;
using ECommerceAPI.DAL.Concrete.EntityFramework.Context;
using ECommerceAPI.DAL.Concrete.EntityFramework.DataManagment;
using ECommerceAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.DAL.Concrete.EntityFramework
{
    internal class EfUserRepository : EfRepository<User>, IUserRepository
    {
        public EfUserRepository(ShopContext context) : base(context)
        {
        }
    }
}
