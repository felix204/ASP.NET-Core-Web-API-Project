using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Entity.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerceAPI.DAL.Abstract.DataManagment
{
    public interface IRepostory<T> where T : AuditableEntity
    {
        Task<T> GetAsync(Expression<Func<T,bool>>Filter, params string[] IncludeProperties);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>Filter, params string[] IncludeProperties);

        Task<EntityEntry<T>> AddAsync(T Entity);

        Task UpdateAsync(T Entity);

        Task DeleteAsync(T Entity);
    }
}
