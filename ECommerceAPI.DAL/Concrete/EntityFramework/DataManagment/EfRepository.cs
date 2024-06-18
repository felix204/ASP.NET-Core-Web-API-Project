using ECommerceAPI.DAL.Abstract.DataManagment;
using ECommerceAPI.Entity.Base;
using ECommerceAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.DAL.Concrete.EntityFramework.DataManagment
{
    public class EfRepository<T> : IRepostory<T> where T : AuditableEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public EfRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        } 
        public async Task<EntityEntry<T>> AddAsync(T Entity)
        {
            return await _dbSet.AddAsync(Entity);
        }

        public async Task DeleteAsync(T Entity)
        {
            await Task.Run(() =>_dbSet.Remove(Entity));
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties)
        {
            IQueryable<T> query = _dbSet;

            if (Filter!=null)
            {
                query = query.Where(Filter);
            }
            if (IncludeProperties.Length>0)
            {
                foreach (string includeProperties in IncludeProperties)
                {
                    query = query.Include(includeProperties);
                }
            }
            return await Task.Run(() => query);
        
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties)
        {
            IQueryable<T> query = _dbSet;

            if (IncludeProperties.Length > 0)
            {
                foreach (string includeProperties in IncludeProperties)
                {
                    query = query.Include(includeProperties);
                }
            }
            return await query.SingleOrDefaultAsync(Filter); 
        }

        public async Task UpdateAsync(T Entity)
        {
            await Task.Run(() => _dbSet.Update(Entity));
        }
    }
}
  