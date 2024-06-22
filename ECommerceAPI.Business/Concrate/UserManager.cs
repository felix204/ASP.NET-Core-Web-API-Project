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
    public class UserManager : IUserServices
    {
        private readonly IUnitOfWork _uow;

        public UserManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<User> AddAsync(User Entity)
        {
            await _uow.UserRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task DeleteAsync(User Entity)
        {
            await _uow.UserRepository.DeleteAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.UserRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.UserRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task UpdateAsync(User Entity)
        {
            await _uow.UserRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
