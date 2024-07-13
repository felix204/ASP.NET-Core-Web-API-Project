using ECommerceAPI.DAL.Abstract;
using ECommerceAPI.DAL.Abstract.DataManagment;
using ECommerceAPI.DAL.Concrete.EntityFramework.Context;
using ECommerceAPI.Entity.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.DAL.Concrete.EntityFramework.DataManagment
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ShopContext _shopContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EFUnitOfWork(ShopContext shopContext)
        {
            _shopContext = shopContext;
            ProductRepository = new EfProductRepository(_shopContext);
            UserRepository = new EfUserRepository(_shopContext);
            OrderDetailRepository=new EfOrderDetailRepository(_shopContext);
            OrderRepository=new EfOrderRepository(_shopContext);
            CategoryRepository=new EFCategoryRepository(_shopContext);
        }

        public IProductRepository ProductRepository { get; }
        public IOrderDetailRepository OrderDetailRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IUserRepository UserRepository { get; }

        public async Task<int> SaveChangeAsync()
        {
            foreach (EntityEntry<AuditableEntity> i in _shopContext.ChangeTracker.Entries<AuditableEntity>())
            {
                if (i.State==Microsoft.EntityFrameworkCore.EntityState.Added)
                {
                    i.Entity.AddedTime = DateTime.Now;
                    i.Entity.UpdatedTime = DateTime.Now;
                    i.Entity.AddedUser = 1;
                    i.Entity.UpdatedIPv4Adress = "1";
                    i.Entity.Guid = Guid.NewGuid();

                    if (i.Entity.IsActive==null)
                    {
                        i.Entity.IsActive = true;
                    }
                    i.Entity.IsDeleted = false;
                }

                else if (i.State==Microsoft.EntityFrameworkCore.EntityState.Modified)
                {
                    i.Entity.UpdatedTime = DateTime.Now;
                    i.Entity.UpdatedIPv4Adress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                }
            }
            return await _shopContext.SaveChangesAsync();
        }
    }
}
