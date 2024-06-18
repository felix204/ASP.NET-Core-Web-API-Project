using ECommerceAPI.Business.Abstract;
using ECommerceAPI.DAL.Abstract.DataManagment;
using ECommerceAPI.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Business.Concrate
{
    public class OrderDetailManager : IOrderDetailServices
    {
        private readonly IUnitOfWork _uow;

        public OrderDetailManager(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public async Task<OrderDetail> AddAsync(OrderDetail Entity)
        {
            await _uow.OrderDetailRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task DeleteAsync(OrderDetail Entity)
        {
            await _uow.OrderDetailRepository.DeleteAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<OrderDetail>> GetAllAsync(Expression<Func<OrderDetail, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.OrderDetailRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<OrderDetail> GetAsync(Expression<Func<OrderDetail, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.OrderDetailRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task UpdateAsync(OrderDetail Entity)
        {
            await _uow.OrderDetailRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
