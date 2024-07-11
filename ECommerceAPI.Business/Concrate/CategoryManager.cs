using ECommerceAPI.Business.Abstract;
using ECommerceAPI.DAL.Abstract;
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
    public class CategoryManager: ICategoryServices
    {
        private readonly IUnitOfWork _uow;
        

        public CategoryManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Category> AddAsync(Category Entity)
        {
            await _uow.CategoryRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task DeleteAsync(Category Entity)
        {
            await _uow.CategoryRepository.DeleteAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync(Expression<Func<Category, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.CategoryRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Category> GetAsync(Expression<Func<Category, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.CategoryRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task UpdateAsync(Category Entity)
        {
            await _uow.CategoryRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
